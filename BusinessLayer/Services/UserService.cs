
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper<Word, WordDTO> _wordMapper;
        private readonly IMapper<User, UserDTO> _userMapper;
        private readonly User _currentUser;

        public UserService(IRepositoryWrapper repoWrapper, IHttpContextAccessor httpContextAccessor, IMapper<Word, WordDTO> wordMapper, IMapper<User, UserDTO> userMapper)
        {
            _repoWrapper = repoWrapper;
            _wordMapper = wordMapper;
            _userMapper = userMapper;
            _currentUser = _repoWrapper.User.FindByCondition(u => u.UserName.Equals(httpContextAccessor.HttpContext.User.Identity.Name))
                   .FirstOrDefault();
        }

        public void Save()
        {
            _repoWrapper.Save();
        }

        public IEnumerable<WordDTO> GetSavedWords()
        {
            if (_currentUser != null)
            {
                var savedWords = from sw in _repoWrapper.UserSavedWords.FindAll()
                       where sw.UserId.Equals(_currentUser.Id)
                       join w in _repoWrapper.Word.FindAll() on sw.SavedWordId equals w.Id
                       select w;
                return _wordMapper.MapToDTO(savedWords);
            }
            return null;
        }

        public bool TryAddToSavedWords(long id)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            UserSavedWord savedWord = _repoWrapper
                    .UserSavedWords.FindByCondition(sw => sw.UserId.Equals(_currentUser.Id) && sw.SavedWordId.Equals(word.Id))
                    .FirstOrDefault();
            if (word != null && _currentUser != null && savedWord == null)
            {
                _repoWrapper.User.Attach(_currentUser);
                _repoWrapper.Word.Attach(word);
                UserSavedWord newSavedWord = new UserSavedWord { SavedWord = word, SavedWordId = word.Id, User = _currentUser, UserId = _currentUser.Id};
                _repoWrapper.UserSavedWords.Create(newSavedWord);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }

        public bool TryDeleteSavedWord(long id)
        {
            UserSavedWord savedWord = _repoWrapper
                    .UserSavedWords.FindByCondition(sw => sw.UserId.Equals(_currentUser.Id) && sw.SavedWordId.Equals(id))
                    .FirstOrDefault();
            if (savedWord != null)
            {
                _repoWrapper.UserSavedWords.Delete(savedWord);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<WordDTO> GetCreatedWords()
        {
            if (_currentUser != null)
            {
                var createdWords = _repoWrapper.Word.FindByCondition(w => w.AuthorId.Equals(_currentUser.Id));
                return _wordMapper.MapToDTO(createdWords);
            }
            return null;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _userMapper.MapToDTO(_repoWrapper.User.FindAll());
        }
    }
}
