using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        IWordRepository Word { get; }
        IUserRepository User { get; }
        ITagRepository Tag { get; }
        void Save();
    }
}
