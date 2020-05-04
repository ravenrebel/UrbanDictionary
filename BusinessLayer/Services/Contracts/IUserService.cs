

using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<WordDTO> GetSavedWords();
        public bool TryAddToSavedWords(long id);
        public bool TryDeleteSavedWord(long id);

        public IEnumerable<WordDTO> GetCreatedWords();

        public void Save();
    }
}
