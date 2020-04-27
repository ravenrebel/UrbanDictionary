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
            return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(name))
                .OrderByDescending(w => w.LikesCount).ThenBy(w => w.DislikesCount).ToList());
        }

        public bool TryCreate(WordDTO wordDto)
        {
            Word word = _mapper.MapToEntity(wordDto);
            _repoWrapper.Word.Create(word);
            foreach (string tagName in wordDto.Tags)
            {
                Tag tag = _repoWrapper.Tag.FindByCondition(t => t.Name.Equals(tagName)).FirstOrDefault();
                if (tag == null)
                {
                    tag = new Tag();
                    tag.Name = tagName;
                    _repoWrapper.Tag.Create(tag);
                }
                else
                {
                    _repoWrapper.Tag.Attach(tag);
                }
                WordTag wordTag = new WordTag { Tag = tag, Word = word, TagId = tag.Id, WordId = word.Id };
                _repoWrapper.WordTag.Create(wordTag);
            }
            _repoWrapper.Save();
            return true;
        }

        public bool TryDelete(long id)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            if (word != null)
            {
                _repoWrapper.Word.Delete(word);
                IEnumerable<Tag> tags = _repoWrapper.Tag.GetByWordId(word.Id);
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

        public bool TryUpdateWordStatus(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WordDTO> GetByTagName()
        {
            throw new NotImplementedException();
        }
    }
}
