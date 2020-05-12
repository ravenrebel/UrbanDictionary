
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Implement the many-to-many relationship with  <see cref="Entities.Tag"/> and its saved <see cref="Entities.Word"/>.
    /// </summary>
    public class WordTag
    {
        /// <summary>
        /// <see cref="Entities.Word"/> Id of words with particular <see cref="Tag"/>.
        /// </summary>
        public long WordId { get; set; }
        [ForeignKey("WordId")]
        public Word Word { get; set; }

        /// <summary>
        /// <see cref="Entities.Tag"/> Id of words with particular <see cref="Word"/>.
        /// </summary>
        public long TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
