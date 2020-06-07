
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Implement the many-to-many relationship with  <see cref="Entities.User"/> and its saved <see cref="Entities.Word"/>.
    /// </summary>
    public class UserSavedWord
    {
        /// <summary>
        /// Id of specific <see cref="User"/>
        /// </summary>
        public string UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// <see cref="User"/>s saved <see cref="Entities.Word"/> Id.
        /// </summary>
        public long SavedWordId { get; set; }  
        public Word SavedWord { get; set; }
    }
}
