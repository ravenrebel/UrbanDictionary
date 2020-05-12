using System;
using System.Collections.Generic;
using System.Linq;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BusinessLayer.DTO.Mapper
{
    /// <inheritdoc cref="IMapper{TEntity, TDTO}"/>
    public class UserServiceMapper : IMapper<User, UserDTO>
    {
        private IRepositoryWrapper _repoWrapper;

        public UserServiceMapper(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public UserDTO MapToDTO(User entity)
        {
            return new UserDTO { Id = entity.Id, Email = entity.Email, UserName = entity.UserName };
        }

        public User MapToEntity(UserDTO dto)
        {
            return _repoWrapper.User.FindByCondition(u => u.Id.Equals(dto.Id)).FirstOrDefault();
        }
    }
}
