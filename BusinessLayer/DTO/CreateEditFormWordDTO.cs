
using System.Collections.Generic;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
    /// <summary>
    /// Contains information about <see cref="Word"/>  that <see cref="User"/> can create and edit.
    /// Also contains its primary key.
    /// </summary>
    public class CreateEditFormWordDTO
    {
        ///<inheritdoc cref="BaseEntity.Id"/>     
        public long Id { get; set; }

        ///<inheritdoc cref="Word.Name"/>  
        public string Name { get; set; }

        ///<inheritdoc cref="Word.Definition"/> 
        public string Definition { get; set; }

        ///<inheritdoc cref="Word.Example"/> 
        public string Example { get; set; }

        ///<inheritdoc cref="Word.Image"/> 
        public string Image { get; set; }

        /// <summary>
        /// Returns <see cref="Tag.Name"/> of each <see cref="Tag"/> from <see cref="Word"/>'s <see cref="Tag"/> collection.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}
