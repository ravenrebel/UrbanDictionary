
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    /// <summary>
    /// Contains information about <see cref="User"/> that is accessible for users.
    /// </summary>
    public class UserDTO
    {
        /// <inheritdoc cref="BaseEntity.Id"/>
        public string Id { get; set; }

        /// <summary>
        /// Unique name, that should be used  for login and mark the author of the <see cref="Word"/>
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Unique <see cref="User"/>'s email.
        /// </summary>
        public string Email { get; set; }
    }
}
