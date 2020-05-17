using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IServiceWrapper _serviceWrapper;

        public AccountController(IServiceWrapper serviceWrapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _serviceWrapper = serviceWrapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("signUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpFormDTO signUpForm)
        {
            User registeredUser = await _userManager.FindByNameAsync(signUpForm.UserName);
            if (registeredUser != null)
            {
                return Ok();
            }

            User user = new User { Email = signUpForm.Email, UserName = signUpForm.UserName };
           
            var result = await _userManager.CreateAsync(user, signUpForm.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                _serviceWrapper.Save();
                await _signInManager.SignInAsync(user, false);
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new { user.UserName, user.Email, Role = roles.First() });
            }
           
            else return Ok();
        }

        [HttpPost("signIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInFormDTO signInForm)
        {
            var result =
                   await _signInManager.PasswordSignInAsync(signInForm.UserName, signInForm.Password, signInForm.RememberMe, false);
            if (result.Succeeded)
            {
                User user = await _userManager.FindByNameAsync(signInForm.UserName);
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new { user.UserName, user.Email, Role = roles.First()});
            }

            if (result.IsLockedOut)
            {
                return Ok(false);
            }

            else return Ok(false);
        }

        [HttpPost("signOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}