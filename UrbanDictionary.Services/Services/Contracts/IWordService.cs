
using System.Collections.Generic;
using UrbanDictionary.BussinessLayer.DTO;


namespace UrbanDictionary.BussinessLayer.Services.Contracts
{
    public interface IWordService
    {
        public IEnumerable<WordDTO> GetAll();

        public WordDTO GetRandom();
    }
}
