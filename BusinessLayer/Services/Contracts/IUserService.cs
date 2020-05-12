using System;
using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains methods for performing actions with users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns><see cref="UserDTO"/> collection</returns>
        public IEnumerable<UserDTO> GetAll();
        /// <summary>
        /// Gets users by <see cref="UserDTO.UserName"/>
        /// </summary>
        /// <param name="name"><see cref="UserDTO.UserName"/></param>
        /// <returns><see cref="UserDTO"/> collection</returns>
        public IEnumerable<UserDTO> GetByUserName(string name);
    }
}
