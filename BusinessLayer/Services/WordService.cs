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

        public WordDTO GetRandom()
        {
            return _mapper.MapToDTO(_repoWrapper.Word.GetRandom());
        }

        public IEnumerable<WordDTO> GetByName(string name)
        {
            return _mapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.Name.Equals(name)).ToList());
        }

        public bool TryCreate(WordDTO wordDto)//TODO: Tags adding 
        {
            Word word = _mapper.MapToEntity(wordDto);
            _repoWrapper.Word.Create(word);
            _repoWrapper.Save();
            return true;
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
            throw new NotImplementedException();
        }

        public IEnumerable<WordDTO> GetLastTenAdded()
        {
            throw new NotImplementedException();
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
