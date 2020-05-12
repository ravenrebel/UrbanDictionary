using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Contains basic properties for other entities.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Unique reference to the specific entity. PK.
        /// </summary>
        [Key]
        public long Id { get; set; } = 0;
    }
}
