using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public IList<WordTag> WordTags { get; set; }
    }
}
