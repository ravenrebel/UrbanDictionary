using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Identifier for categorization, description, <see cref="Word"/> retrieval.
    /// </summary>
    public class Tag : BaseEntity
    {
        /// <summary>
        /// <see cref="Tag"/> Name property.
        /// </summary>
        [Required]
        public string Name { get; set; }

        public IList<WordTag> WordTags { get; set; }
    }
}
