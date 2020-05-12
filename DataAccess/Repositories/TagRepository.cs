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
    /// <inheritdoc cref="ITagRepository"/>
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        private readonly UrbanDictionaryDBContext _context;
        
        /// <summary>
        /// <see cref="TagRepository"/> constructor.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public TagRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
