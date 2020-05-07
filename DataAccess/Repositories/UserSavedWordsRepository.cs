using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Data;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.DataAccess.Repositories
{
    public class UserSavedWordsRepository : RepositoryBase<UserSavedWord>, IUserSavedWordsRepository
    {
        private readonly UrbanDictionaryDBContext _context;

        public UserSavedWordsRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
