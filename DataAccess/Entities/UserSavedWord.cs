using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    [Table("UserSavedWord")]
    public class UserSavedWord : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public long SavedWordId { get; set; }
        public Word SavedWord { get; set; }
    }
}
