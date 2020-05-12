using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Data
{
    /// <inheritdoc cref="IdentityDbContext"/>
    public class UrbanDictionaryDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public UrbanDictionaryDBContext(DbContextOptions<UrbanDictionaryDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Returns the <see cref="DbSet{TEntity}"/> of <see cref="Users"/>s.
        /// </summary> 
        public new DbSet<User> Users { get; set; }

        /// <summary>
        /// Returns the <see cref="DbSet{TEntity}"/> of <see cref="Word"/>s.
        /// </summary>
        public DbSet<Word> Words { get; set; }

        /// <summary>
        /// Returns the <see cref="DbSet{TEntity}"/> of <see cref="Tag"/>s.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Returns the <see cref="DbSet{TEntity}"/> of <see cref="WordTag"/>s.
        /// </summary>
        public DbSet<WordTag> WordTags { get; set; }

        /// <summary>
        /// Returns the <see cref="DbSet{TEntity}"/> of <see cref="UserSavedWord"/>s.
        /// </summary>
        public DbSet<UserSavedWord> UserSavedWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WordTag>()
              .HasKey(wt => new { wt.WordId, wt.TagId });

            modelBuilder.Entity<WordTag>()
               .HasOne<Word>(wt => wt.Word)
               .WithMany(w => w.WordTags)
               .HasForeignKey(wt => wt.WordId);

            modelBuilder.Entity<WordTag>()
                .HasOne<Tag>(wt => wt.Tag)
                .WithMany(t => t.WordTags)
                .HasForeignKey(wt => wt.TagId);

            modelBuilder.Entity<UserSavedWord>()
              .HasKey(uw => new { uw.UserId, uw.SavedWordId });

            modelBuilder.Entity<UserSavedWord>()
               .HasOne<User>(uw => uw.User)
               .WithMany(u => u.UserSavedWords)
               .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<UserSavedWord>()
                .HasOne<Word>(uw => uw.SavedWord)
                .WithMany(w => w.UserSavedWords)
                .HasForeignKey(uw => uw.SavedWordId);

            List<Word> defaultWords = new List<Word>();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                defaultWords.Add(new Word
                {
                    Id = i + 1,
                    Name = "DefaultWordName" + random.Next(10),
                    Definition = "Default word definition",
                    Example = "Default word example",
                    WordStatus = WordStatus.Сonfirmed,
                    LikesCount = 100,
                    DislikesCount = 31,
                    CreationDate = default,
                    AuthorId = "default",
                });
            }

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "default",
                UserName = "DefaultUserName",
                Email = "email@default.com",
                EmailConfirmed = true,
                PhoneNumber = "000000000",
                AccessFailedCount = 0,
                LockoutEnabled = true,
                NormalizedEmail = "EMAIL@DEFAULT.COM",
                LockoutEnd = default,
                NormalizedUserName = "DEFAULTUSERNAME",
                ConcurrencyStamp = "default",
                PhoneNumberConfirmed = true,
                SecurityStamp = "default",
                TwoFactorEnabled = false,
                PasswordHash = "defaultHash"
            });
            modelBuilder.Entity<Word>().HasData(defaultWords);
        }
    }
}
