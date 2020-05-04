﻿
using Microsoft.AspNetCore.Http;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private ITagService _tag;
        private IWordService _word;
        private IRepositoryWrapper _repoWrapper;
        private IMapper<Word, WordDTO> _wordMapper;
        private IMapper<Tag, TagDTO> _tagMapper;
        private IMapper<User, UserDTO> _userMapper;
        private IHttpContextAccessor _httpContext;

        public ServiceWrapper(IRepositoryWrapper repoWrapper, IMapper<Word, WordDTO> wordMapper, IMapper<Tag, TagDTO> tagMapper, 
            IHttpContextAccessor httpContext, IMapper<User, UserDTO> userMapper)
        {
            _repoWrapper = repoWrapper;
            _wordMapper = wordMapper;
            _tagMapper = tagMapper;
            _userMapper = userMapper;
            _httpContext = httpContext;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoWrapper, _httpContext, _wordMapper, _userMapper);
                }

                return _user;
            }
        }

        public IWordService Word
        {
            get
            {
                if (_word == null)
                {
                    _word = new WordService(_repoWrapper, _wordMapper);
                }

                return _word;
            }
        }

        public ITagService Tag
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagService(_repoWrapper, _tagMapper);
                }

                return _tag;
            }
        }
    }
}
