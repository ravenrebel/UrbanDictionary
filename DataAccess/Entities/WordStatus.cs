using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.DataAccess.Entities
{
    /// <summary>
    /// Enumeration of different <see cref="Word"/> statuses.
    /// </summary>
   public enum WordStatus
    {
        /// <summary>
        /// All users can search the <see cref="Word"/>
        /// </summary>
        Сonfirmed,
        /// <summary>
        /// The <see cref="Word"/> was disapproved by moderator and other users cannot search it.
        /// </summary>
        Unconfirmed,
        /// <summary>
        /// The <see cref="Word"/> is considered by moderator.
        /// </summary>
        OnModeration
    }
}
