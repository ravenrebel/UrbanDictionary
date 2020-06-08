
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Data;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContextPool<UrbanDictionaryDBContext>(options =>
            //    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<UrbanDictionaryDBContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Admin");
                    });
            });

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UrbanDictionary API", Version = "v1" }); 
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.AddAuthentication();
            //.AddGoogle(options =>
            //{
            //    options.ClientId = Configuration.GetSection("GoogleAuthentication:GoogleClientId").Value;
            //    options.ClientSecret = Configuration.GetSection("GoogleAuthentication:GoogleClientSecret").Value;
            //});

            //services.Configure<DataProtectionTokenProviderOptions>(options =>
            //    options.TokenLifespan = TimeSpan.FromHours(3));

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.LoginPath = "/api/account/login";
                options.LogoutPath = "/api/account/logout";
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var roles = new List<string>() { "Admin", "Moderator", "User" };
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    IdentityRole idRole = new IdentityRole
                    {
                        Name = role
                    };

                    var res = await roleManager.CreateAsync(idRole);
                }
            }

            IConfigurationSection admin = Configuration.GetSection("Admin");
            User profile = new User
            {
                Email = admin["Email"],
                UserName = admin["Email"],
                EmailConfirmed = true
            };
            if (await userManager.FindByEmailAsync(admin["Email"]) == null)
            {
                var res = await userManager.CreateAsync(profile, admin["Password"]);
                if (res.Succeeded)
                    await userManager.AddToRoleAsync(profile, "Admin");
            }
            else if (!await userManager.IsInRoleAsync(userManager.Users.First(item => item.Email == profile.Email), "Admin"))
            {
                var user = userManager.Users.First(item => item.Email == profile.Email);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var options = new DbContextOptionsBuilder<UrbanDictionaryDBContext>();
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                return new UrbanDictionaryDBContext(options.Options);
            });
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>();
            builder.RegisterType<ServiceWrapper>().As<IServiceWrapper>();
            builder.RegisterType<WordServiceMapper>().As<IMapper<Word, WordDTO>>();
            builder.RegisterType<TagServiceMapper>().As<IMapper<Tag, TagDTO>>();
            builder.RegisterType<UserServiceMapper>().As<IMapper<User, UserDTO>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            CreateRoles(services).Wait();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrbanDictionary API V1");
            });
        }
    }
}
