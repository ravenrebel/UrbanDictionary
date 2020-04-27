﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp(SignUpFormDTO signUpForm)
        {
            User user = new User { Email = signUpForm.Email, UserName = signUpForm.UserName };
            var result = await _userManager.CreateAsync(user, signUpForm.Password);
            if (result.Succeeded)
            {
                _serviceWrapper.User.Create();
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost("signIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn(SignInFormDTO signInForm)
        {
            var result =
                   await _signInManager.PasswordSignInAsync(signInForm.UserName, signInForm.Password, signInForm.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok();
            } 
            else return BadRequest();
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