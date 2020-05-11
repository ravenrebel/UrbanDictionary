using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Contains basic queries for <see cref="UserSavedWord"/>.
    /// </summary>
    public interface IUserSavedWordsRepository : IRepositoryBase<UserSavedWord>
    {
    }
}
