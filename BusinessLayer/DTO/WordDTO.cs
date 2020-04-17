using System;
using System.Collections.Generic;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    public class WordDTO
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Definition { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreationDate { get; set; }

        public string Example { get; set; }

        public string Image { get; set; }

        public WordStatus WordStatus { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
