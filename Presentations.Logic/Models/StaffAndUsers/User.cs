using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Models
{
    public class User
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}