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
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        private readonly UrbanDictionaryDBContext _context;
        
        public TagRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Tag> GetByWordId(long id)
        {
            var tags = from wt in _context.WordTags
                where  wt.WordId.Equals(id)
                join t in _context.Tags on wt.TagId equals t.Id
                select t;
            return tags.ToList();
        } 
    }
}
