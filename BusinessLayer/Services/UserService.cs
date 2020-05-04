using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<User, UserDTO> _userMapper;

        public UserService(IRepositoryWrapper repoWrapper, IMapper<User, UserDTO> userMapper)
        {
            _repoWrapper = repoWrapper;
            _userMapper = userMapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userMapper.MapToDTO(_repoWrapper.User.FindAll());
        }

        public bool TryDelete(string id)
        {
            User user = _repoWrapper.User.FindByCondition(u => u.Id.Equals(id)).FirstOrDefault();
            if (user != null)
            {
                _repoWrapper.User.Delete(user);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }
    }
}
