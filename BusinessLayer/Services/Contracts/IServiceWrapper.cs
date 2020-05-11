using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains all services for performing actions with <c>Word</c>, <c>User</c>, <c>Tag</c> entities.
    /// </summary>
    public interface IServiceWrapper
    {
        /// <inheritdoc cref="IWordService"/>
        IWordService Word { get; }
        /// <inheritdoc cref="IUserWordsService"/>
        IUserWordsService UserWords { get; }
        ITagService Tag { get; }
        IUserService User { get; }

        /// <summary>
        /// Save changes to database.
        /// </summary>
        void Save();
    }
}
