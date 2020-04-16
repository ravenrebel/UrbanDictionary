using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BussinessLayer.DTO
{
    public class TagDTO
    {
        public string Name { get; set; }

        public IList<Word> Words { get; set; }
    }
}
