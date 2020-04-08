using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public IList<Word> CreatedWords { get; set; }

        public IList<UserSavedWord> UserSavedWords { get; set; }
    }
}
