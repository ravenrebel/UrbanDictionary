using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    public class Word : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Definition { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string Example { get; set; }

        public string Image { get; set; }

        public WordStatus WordStatus { get; set; } = WordStatus.OnModeration;

        public int LikesCount { get; set; } = 0;

        public int DislikesCount { get; set; } = 0;

        public IList<WordTag> WordTags { get; set; }

        public IList<UserSavedWord> UserSavedWords { get; set; }
    }
}
