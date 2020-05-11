using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Data;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.DataAccess.Repositories
{
    /// <inheritdoc cref="IUserSavedWordsRepository"/>
    public class UserSavedWordsRepository : RepositoryBase<UserSavedWord>, IUserSavedWordsRepository
    {
        private readonly UrbanDictionaryDBContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public UserSavedWordsRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
