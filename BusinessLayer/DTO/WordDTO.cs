using System;
using System.Collections.Generic;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    /// <summary>
    /// Contains information about <see cref="Word"/> that is accessible for users.
    /// </summary>
    public class WordDTO
    {
        /// <inheritdoc cref="BaseEntity.Id"/>
        public long Id { get; set; }

        /// <inheritdoc cref="Word.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="Word.Definition"/>
        public string Definition { get; set; }

        /// <summary>
        /// Name or the <see cref="User"/> the <see cref="Word"/> is created by.
        /// </summary>
        public string AuthorName { get; set; }

        /// <inheritdoc cref="Word.CreationDate"/>
        public DateTime CreationDate { get; set; }

        /// <inheritdoc cref="Word.Example"/>
        public string Example { get; set; }

        /// <inheritdoc cref="Word.Image"/>
        public string Image { get; set; }

        /// <inheritdoc cref="Word.WordStatus"/>
        public WordStatus WordStatus { get; set; }

        /// <inheritdoc cref="Word.LikesCount"/>
        public int LikesCount { get; set; }

        /// <inheritdoc cref="Word.DislikesCount"/>
        public int DislikesCount { get; set; }

        /// <inheritdoc cref="CreateEditFormWordDTO.Tags"/>
        public IEnumerable<string> Tags { get; set; }
    }
}
