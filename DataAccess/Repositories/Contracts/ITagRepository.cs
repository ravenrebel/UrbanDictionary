using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        IEnumerable<Tag> GetByWordId(long id);
    }
}
