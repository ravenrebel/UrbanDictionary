
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDictionary.DataAccess.Entities
{
    public class UserSavedWord
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public long SavedWordId { get; set; }  
        [ForeignKey("SavedWordId")]
        public Word SavedWord { get; set; }
    }
}
