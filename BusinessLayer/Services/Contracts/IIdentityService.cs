using Microsoft.AspNetCore.Http;
using UrbanDictionary.BusinessLayer.DTO;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IIdentityService
    {
        void Login(LoginDTO login, HttpContext httpContext);
    }
}
