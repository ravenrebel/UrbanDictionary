
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDictionary.DataAccess.Entities
{
   public class WordTag
    {
        public long WordId { get; set; }
        [ForeignKey("WordId")]
        public Word Word { get; set; }

        public long TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
