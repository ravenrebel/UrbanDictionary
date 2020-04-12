using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BussinessLayer.Services
{
    public class WordService : IWordService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public WordService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IEnumerable<Word> GetAll()
        {
            return _repoWrapper.Word.FindAll().ToList();
        }
    }
}
