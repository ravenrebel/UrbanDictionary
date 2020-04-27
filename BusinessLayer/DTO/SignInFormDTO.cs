using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.BusinessLayer.DTO
{
    public class SignInFormDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
