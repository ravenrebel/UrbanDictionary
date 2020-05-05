
using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;


namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IWordService
    {
        IEnumerable<WordDTO> GetAll();
        IEnumerable<WordDTO> GetRandom();
        IEnumerable<WordDTO> GetByName(string name);
        bool TryDelete(long id);
        IEnumerable<WordDTO> GetTopTen();
        IEnumerable<WordDTO> GetLastTenAdded();
        bool TryApproveWord(long id);
        bool TryDisapproveWord(long id);
        IEnumerable<WordDTO> GetByTagName(string tag);
    }
}
