using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.XUnit
{
    public class ServiceWrapperTests
    {
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IMapper<Word, WordDTO>> _wordMapper;
        private Mock<IMapper<Tag, TagDTO>> _tagMapper;
        private Mock<IMapper<User, UserDTO>> _userMapper;
        private Mock<IHttpContextAccessor> _httpContext;

        public ServiceWrapperTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _wordMapper = new Mock<IMapper<Word, WordDTO>>();
            _tagMapper = new Mock<IMapper<Tag, TagDTO>>();
            _userMapper = new Mock<IMapper<User, UserDTO>>();
            _httpContext = new Mock<IHttpContextAccessor>();
        }
 
    }
}
