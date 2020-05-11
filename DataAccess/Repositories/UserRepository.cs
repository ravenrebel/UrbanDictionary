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
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public UserRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
