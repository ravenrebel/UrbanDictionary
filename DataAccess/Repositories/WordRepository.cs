using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using UrbanDictionary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Repositories
{
    public class WordRepository : RepositoryBase<Word>, IWordRepository
    {
        public WordRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
