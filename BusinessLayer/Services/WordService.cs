using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.Services
{
    public class WordService : IWordService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<Word, WordDTO> _mapper;

        public WordService(IRepositoryWrapper repoWrapper, IMapper<Word, WordDTO> mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public IEnumerable<WordDTO> GetAll()
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindAll().ToList());
        }

        public IEnumerable<WordDTO> GetRandom()
        {
            string name = _repoWrapper.Word.FindAll().OrderBy(w => Guid.NewGuid()).First().Name;
            return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(name)).ToList());
        }

        public IEnumerable<WordDTO> GetByName(string name)
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(name) && w.WordStatus.Equals(WordStatus.Сonfirmed))
                .OrderByDescending(w => w.LikesCount).ThenBy(w => w.DislikesCount).ToList());
        }

        public bool TryDelete(long id)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            if (word != null)
            {
                _repoWrapper.Word.Delete(word);
                _repoWrapper.Save();

                return true;
            }
            return false;
        }

        public IEnumerable<WordDTO> GetTopTen()
        {
            return _mapper.MapToDTO( _repoWrapper.Word.FindAll().OrderByDescending(w => w.LikesCount)
                .ThenBy(w => w.DislikesCount)
                .Take(10).ToList());
        }

        public IEnumerable<WordDTO> GetLastTenAdded()
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindAll().OrderByDescending(w => w.CreationDate).Take(10).ToList());
        }

        public bool TryApproveWord(long id)
        {
            return ChangeWordStatus(id, WordStatus.Сonfirmed);
        }

        public bool TryDisapproveWord(long id)
        {
            return ChangeWordStatus(id, WordStatus.Unconfirmed);
        }

        private bool ChangeWordStatus(long id, WordStatus status)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            if (word != null)
            {
                if (word.WordStatus.Equals(WordStatus.OnModeration))
                {
                    word.WordStatus = status;
                    _repoWrapper.Word.Update(word);
                    _repoWrapper.Save();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<WordDTO> GetByTagName(string tag)
        {
            var words = from t in _repoWrapper.Tag.FindAll()
                   where t.Name.Equals(tag)
                   join wt in _repoWrapper.WordTag.FindAll() on t.Id equals wt.TagId
                   join w in _repoWrapper.Word.FindAll() on wt.WordId equals w.Id
                   select w;
            return _mapper.MapToDTO(words);
        }
    }
}
