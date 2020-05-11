using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <inheritdoc cref="IdentityUser"/>
    public class User : IdentityUser
    {
        /// <summary>
        /// Created words of <see cref="User"/>, that can be edit and deleted.
        /// </summary>
        public IList<Word> CreatedWords { get; set; }

        /// <summary>
        /// Words that <see cref="User" /> saved.
        /// </summary>
        public IList<UserSavedWord> UserSavedWords { get; set; }
    }
}
