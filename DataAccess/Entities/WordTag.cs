using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
   public class WordTag : BaseEntity
    {
        public long WordId { get; set; }
        public Word Word { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
