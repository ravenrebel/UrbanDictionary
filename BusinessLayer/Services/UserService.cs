
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper<Word, WordDTO> _wordMapper;

        public UserService(IRepositoryWrapper repoWrapper, IHttpContextAccessor httpContextAccessor, IMapper<Word, WordDTO> wordMapper)
        {
            _repoWrapper = repoWrapper;
            _httpContextAccessor = httpContextAccessor;
            _wordMapper = wordMapper;
        }

        public void Save()
        {
            _repoWrapper.Save();
        }

        public IEnumerable<WordDTO> GetSavedWords()
        {
            User currentUser = _repoWrapper.User.FindByCondition(u =>u.UserName.Equals(_httpContextAccessor.HttpContext.User.Identity.Name))
                .FirstOrDefault();
            if (currentUser != null)
            {
                var savedWords = from sw in _repoWrapper.UserSavedWords.FindAll()
                       where sw.UserId.Equals(currentUser.Id)
                       join w in _repoWrapper.Word.FindAll() on sw.SavedWordId equals w.Id
                       select w;
                return _wordMapper.MapToDTO(savedWords.ToList());
            }
            return null;
        }

        public bool TryAddToSavedWords(long id)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            User currentUser = _repoWrapper.User.FindByCondition(u => u.UserName.Equals(_httpContextAccessor.HttpContext.User.Identity.Name))
                    .FirstOrDefault(); 
            UserSavedWord savedWord = _repoWrapper
                    .UserSavedWords.FindByCondition(sw => sw.UserId.Equals(currentUser.Id) && sw.SavedWordId.Equals(word.Id))
                    .FirstOrDefault();
            if (word != null && currentUser != null && savedWord == null)
            {
                _repoWrapper.User.Attach(currentUser);
                _repoWrapper.Word.Attach(word);
                UserSavedWord newSavedWord = new UserSavedWord { SavedWord = word, SavedWordId = word.Id, User = currentUser, UserId = currentUser.Id};
                _repoWrapper.UserSavedWords.Create(newSavedWord);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }
    }
}
