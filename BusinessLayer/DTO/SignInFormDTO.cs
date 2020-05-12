
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    /// <summary>
    /// Contains needed information for <see cref="User"/> to login.
    /// </summary>
    public class SignInFormDTO
    {
        /// <inheritdoc cref="UserDTO.UserName"/>
        public string UserName { get; set; }

        /// <summary>
        /// <see cref="User"/> password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Determines whether <see cref="User"/> will have access from same machine to all its data even after session expired. 
        /// This access will be possible until user does a logout.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
