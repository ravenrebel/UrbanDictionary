using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; } = 0;
    }
}
