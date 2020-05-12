using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains all services for performing actions with <see cref="DataAccess.Entities.Word"/>, <see cref="DataAccess.Entities.User"/>, <see cref="DataAccess.Entities.Tag"/> entities.
    /// </summary>
    public interface IServiceWrapper
    {
        /// <inheritdoc cref="IWordService"/>
        IWordService Word { get; }

        /// <inheritdoc cref="IUserWordsService"/>
        IUserWordsService UserWords { get; }

        /// <inheritdoc cref="ITagService"/>
        ITagService Tag { get; }

        /// <inheritdoc cref="IUserService"/>
        IUserService User { get; }

        /// <summary>
        /// Save changes to database.
        /// </summary>
        void Save();
    }
}
