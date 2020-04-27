using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UrbanDictionary.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public Role Role { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public IList<Word> CreatedWords { get; set; }
        public IList<UserSavedWord> UserSavedWords { get; set; }
    }
}
