
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    /// <summary>
    /// Contains needed information for <see cref="User"/> to register.
    /// </summary>
    public class SignUpFormDTO
    {
        /// <inheritdoc cref="UserDTO.UserName"/>
        public string UserName { get; set; }

        /// <inheritdoc cref="UserDTO.Email"/>
        public string Email { get; set; }

        /// <inheritdoc cref="SignInFormDTO.Password"/>
        public string Password { get; set; }
    }
}
