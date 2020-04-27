using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BusinessLayer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IRepositoryWrapper repository;

        public IdentityService(IRepositoryWrapper repository)
        {
            this.repository = repository;
            this.repository = repository;
        }

        public void Login(LoginDTO login, HttpContext httpContext)
        {
            var user = CanLogin(login);
            if (user != null)
            {
                Authenticate(user, httpContext);
            }
        }

        public void Registration(RegistrationDTO registration, HttpContext httpContext)
        {
            if (CanRegister(registration))
            {
                var user = new DataAccess.Entities.User
                {
                    UserName = registration.Username,
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email,
                    Role = DataAccess.Role.User,
                    PasswordHash = Crypto.Hash(registration.Password)
                };
                repository.User.Create(user);
                Authenticate(user, httpContext);
            }
        }

        private bool CanRegister(RegistrationDTO registration)
        {
            return repository.User.FindByCondition(i => i.UserName == registration.Username || i.Email == registration.Email).Any();
        }

        private DataAccess.Entities.User CanLogin(LoginDTO login)
        {
            var user = repository.User.FindByCondition(i => i.UserName == login.Username)?.FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            if (!Crypto.VerifyHashedPassword(user.PasswordHash, login.Password))
            {
                return null;
            }
            return user;
        }

        private async void Authenticate(DataAccess.Entities.User user, HttpContext httpContext)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Email, user.Email  ),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}