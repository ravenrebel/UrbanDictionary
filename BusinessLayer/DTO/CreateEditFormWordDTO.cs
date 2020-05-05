using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.BusinessLayer.DTO
{
    public class CreateEditFormWordDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Definition { get; set; }

        public string Example { get; set; }

        public string Image { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
