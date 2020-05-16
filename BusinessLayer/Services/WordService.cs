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

        public IEnumerable<WordDTO> GetRandom()
        {
            string name = _repoWrapper.Word.FindAll().OrderBy(w => Guid.NewGuid()).First().Name;
            return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(name)));
        }

        public IEnumerable<WordDTO> GetByName(string name, int skipNumber)
        {
            return _mapper.MapToDTO(_repoWrapper.Word
                .FindByCondition(w => w.Name.Contains(name) && w.WordStatus.Equals(WordStatus.Сonfirmed))
                .OrderByDescending(w => w.LikesCount)
                .ThenBy(w => w.DislikesCount)
                .Skip(skipNumber));
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
                .Take(10));
        }

        public IEnumerable<WordDTO> GetLastTenAdded()
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindAll().OrderByDescending(w => w.CreationDate).Take(10));
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
            return _mapper.MapToDTO( _repoWrapper.Word.FindByCondition(w => w.WordTags.Any(wt => wt.Tag.Name.Equals(tag))));
        }

        public long GetCountByName(string name)
        {
            return _repoWrapper.Word
                .FindByCondition(w => w.Name.Contains(name) && w.WordStatus.Equals(WordStatus.Сonfirmed))
                .OrderByDescending(w => w.LikesCount)
                .ThenBy(w => w.DislikesCount)
                .Count();
        }
    }
}
