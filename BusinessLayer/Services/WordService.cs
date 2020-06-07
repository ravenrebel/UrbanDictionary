using System;
using System.Collections.Generic;
using System.Linq;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.Services
{
    /// <inheritdoc cref="IWordService"/>
    public class WordService : IWordService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<Word, WordDTO> _mapper;

        /// <summary>
        /// <see cref="WordService"/> contractor.
        /// </summary>
        /// <param name="repoWrapper">Repository</param>
        /// <param name="mapper">Mapper</param>
        public WordService(IRepositoryWrapper repoWrapper, IMapper<Word, WordDTO> mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public IEnumerable<WordDTO> GetAll()
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindAll());
        }

        private IQueryable<Word> GetConfirmed()
        {
            return _repoWrapper.Word.FindByCondition(w => w.WordStatus.Equals(WordStatus.Сonfirmed));
        }

        public IEnumerable<WordDTO> GetRandom()
        {
            Random random = new Random();
            int order = random.Next();
            Word word = GetConfirmed().OrderBy(w => order).FirstOrDefault();
            if (word != null)
                return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(word.Name) && w.WordStatus.Equals(WordStatus.Сonfirmed)));
            else return new List<WordDTO>();
        }

        public IEnumerable<WordDTO> GetByName(string name, int skipNumber)
        {
            return _mapper.MapToDTO(GetByName(name)
                .OrderByDescending(w => w.LikesCount)
                .ThenBy(w => w.DislikesCount)
                .Skip(skipNumber));
        }

        public void Delete(long id)
        {
             _repoWrapper.Word.Delete(_repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault());
             _repoWrapper.Save();
        }

        public IEnumerable<WordDTO> GetTopTen()
        {
            return _mapper.MapToDTO(GetConfirmed()
                .OrderByDescending(w => w.LikesCount)
                .ThenBy(w => w.DislikesCount)
                .Take(10));
        }

        public IEnumerable<WordDTO> GetLastTenAdded()
        {
            return _mapper.MapToDTO(GetConfirmed().OrderByDescending(w => w.CreationDate).Take(10));
        }

        public bool ApproveWord(long id)
        {
            return ChangeWordStatus(id, WordStatus.Сonfirmed);
        }

        public bool DisapproveWord(long id)
        {
            return ChangeWordStatus(id, WordStatus.Unconfirmed);
        }

        private bool ChangeWordStatus(long id, WordStatus status)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id) && w.WordStatus.Equals(WordStatus.OnModeration)).FirstOrDefault();
            if (word != null)
            {
                word.WordStatus = status;
                _repoWrapper.Word.Update(word);
                _repoWrapper.Save();
               return true;
            }
            return false;
        }

        public IEnumerable<WordDTO> GetByTagName(string tag)
        {
            return _mapper.MapToDTO( _repoWrapper.Word
                .FindByCondition(w => w.WordTags.Any(wt => wt.Tag.Name.Equals(tag)) && w.WordStatus.Equals(WordStatus.Сonfirmed)));
        }

        public long GetCountByName(string name)
        {
            return GetByName(name).Count();
        }

        private IQueryable<Word> GetByName(string name)
        {
            return _repoWrapper.Word.FindByCondition(w => w.Name.Contains(name) && w.WordStatus.Equals(WordStatus.Сonfirmed));
        }

        public bool LikeWord(long id)
        {
            Word word = GetConfirmedById(id);
            if (word != null)
            {
                word.LikesCount = word.LikesCount + 1;
                _repoWrapper.Word.Update(word);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }

        public bool DislikeWord(long id)
        {
            Word word = GetConfirmedById(id);
            if (word != null)
            {
                word.DislikesCount = word.DislikesCount + 1;
                _repoWrapper.Word.Update(word);
                _repoWrapper.Save();
                return true;
            }
            return false;
        }

        private Word GetConfirmedById(long id)
        {
            return _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id) && w.WordStatus.Equals(WordStatus.Сonfirmed)).FirstOrDefault();
        }
    }
}
