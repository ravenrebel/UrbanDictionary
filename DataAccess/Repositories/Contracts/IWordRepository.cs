using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Contains basic queries for <see cref="Word"/>.
    /// </summary>
    public interface IWordRepository : IRepositoryBase<Word>
    {
    }
}
