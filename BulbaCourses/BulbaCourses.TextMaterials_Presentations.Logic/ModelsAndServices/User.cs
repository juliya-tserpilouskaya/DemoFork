using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic
{
    public class User
    {
        public string Id { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string PhoneNumber { get; set; }
    }
}