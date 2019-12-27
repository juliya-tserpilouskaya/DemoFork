using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NumberPhone { get; set; } 
        public string Email { get; set; }
        public string ReserveEmail { get; set; }
    }
}