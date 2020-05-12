using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.DTO
{
   /// <summary>
   /// Contains information about <see cref="Tag"/> that is accessible for users. 
   /// </summary>
    public class TagDTO
    {
        /// <inheritdoc cref="BaseEntity.Id"/>
        public long Id { get; set; }

         /// <inheritdoc cref="Tag.Name"/>
        public string Name { get; set; }
    }
}
