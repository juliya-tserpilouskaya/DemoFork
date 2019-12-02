using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class RegisteredUser
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Bookmark> Items { get; set; }
        //public List<SearchQueries> Items { get; set; }
    }
}