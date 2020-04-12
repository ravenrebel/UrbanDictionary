
using System.Collections.Generic;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BussinessLayer.Services.Contracts
{
    public interface IWordService
    {
        public IEnumerable<Word> GetAll();
    }
}
