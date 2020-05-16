using System;
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
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly IServiceWrapper _serviceWrapper;

        public UsersController(IServiceWrapper serviceWrapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _serviceWrapper = serviceWrapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WordDTO>> Get()
        {
            return Ok(_serviceWrapper.User.GetAll());
        }

        [HttpGet("search/{name}")]
        public ActionResult<IEnumerable<WordDTO>> GetByName(string name)
        {
            return Ok(_serviceWrapper.User.GetByUserName(name));
        }

        [HttpPut("changeRole/{id}")]
        public async Task<ActionResult> ChangRole(string id, string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return NotFound(roleName);

            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, roleName)) return Ok(id);

                var userRoles = await _userManager.GetRolesAsync(user);
                userRoles.Remove(roleName);

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, roleName);

                _serviceWrapper.Save();
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpGet("getRoles/{id}")]
        public async Task<ActionResult<string>> getRoles(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return Ok( await _userManager.GetRolesAsync(user));
            }
            return NotFound(id);
        }
    }
}