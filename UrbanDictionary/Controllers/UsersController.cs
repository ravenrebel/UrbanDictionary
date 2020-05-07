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
        private readonly IServiceWrapper _serviceWrapper;

        public UsersController(IServiceWrapper serviceWrapper, UserManager<User> userManager)
        {
            _serviceWrapper = serviceWrapper;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> Get()
        {
            return Ok(_serviceWrapper.User.GetAll());
        }

        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetByName(string name)
        {
            return Ok(_serviceWrapper.User.GetByUserName(name));
        }

        [HttpPut("changeRole/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ChangRole(string id, string role)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, role)) return Ok(id);

                var userRoles = await _userManager.GetRolesAsync(user);
                userRoles.Remove(role);

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, role);

                _serviceWrapper.Save();
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpGet("getRoles/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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