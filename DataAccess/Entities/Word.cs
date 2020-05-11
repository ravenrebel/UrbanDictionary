using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Word of specific language.
    /// </summary>
    public class Word : BaseEntity
    {
        /// <summary>
        /// <see cref="Word"/> Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// <see cref="Word"/> meaning.
        /// </summary>
        [Required]
        public string Definition { get; set; }

        /// <summary>
        /// FK of <see cref="User"/> that create it.
        /// </summary>
        public string AuthorId { get; set; }
        /// <summary>
        /// <see cref="User"/> that create it.
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Time when <see cref="Word"/> was created or its last modification time.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Example of <see cref="Word"/> usage.
        /// </summary>
        public string Example { get; set; }

        /// <summary>
        /// The reference to the image that explain the <see cref="Word"/> somehow.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Show the current <see cref="WordStatus"/>.
        /// </summary>
        public WordStatus WordStatus { get; set; } = WordStatus.OnModeration;

        /// <summary>
        /// How many users liked it.
        /// </summary>
        public int LikesCount { get; set; } = 0;

        /// <summary>
        /// How many users dislike it.
        /// </summary>
        public int DislikesCount { get; set; } = 0;

        /// <summary>
        /// Collection of <see cref="WordTag"/>s.
        /// </summary>
        public IList<WordTag> WordTags { get; set; }

        /// <summary>
        /// Collection of <see cref="UserSavedWord"/>s.
        /// </summary>
        public IList<UserSavedWord> UserSavedWords { get; set; }
    }
}
