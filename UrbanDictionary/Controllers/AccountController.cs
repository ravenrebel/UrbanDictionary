using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public AccountController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("login"), AllowAnonymous]
        public IActionResult Login(LoginDTO login)
        {
            identityService.Login(login, HttpContext);
            return Ok();
        }

        [HttpPost("registration"), AllowAnonymous]
        public IActionResult Registration(RegistrationDTO registration)
        {
            return Ok();
        }
    }
}
