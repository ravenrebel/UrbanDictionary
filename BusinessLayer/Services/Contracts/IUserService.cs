

using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<WordDTO> GetSavedWords();
        public void Save();
    }
}
