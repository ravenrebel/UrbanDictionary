using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Contains all repositories of basic entities.
    /// </summary>
    public interface IRepositoryWrapper
    {
        /// <inheritdoc cref="IWordRepository"/>
        IWordRepository Word { get; }

        /// <inheritdoc cref="IUserRepository"/>
        IUserRepository User { get; }

        /// <inheritdoc cref="ITagRepository"/>
        ITagRepository Tag { get; }

        /// <inheritdoc cref="IWordTagRepository"/>
        IWordTagRepository WordTag { get; }

        /// <inheritdoc cref="IUserSavedWordsRepository"/>
        IUserSavedWordsRepository UserSavedWords { get; }

        /// <summary>
        /// Saves all changes to database.
        /// </summary>
        void Save();
    }
}
