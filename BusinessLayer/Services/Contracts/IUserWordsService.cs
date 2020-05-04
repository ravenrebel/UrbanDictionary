

using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IUserWordsService
    {
        public IEnumerable<WordDTO> GetSavedWords();
        public bool TryAddToSavedWords(long id);
        public bool TryDeleteSavedWord(long id);

        public IEnumerable<WordDTO> GetCreatedWords();
        bool TryCreateWord(WordDTO wordDto);

        public void Save();
    }
}
