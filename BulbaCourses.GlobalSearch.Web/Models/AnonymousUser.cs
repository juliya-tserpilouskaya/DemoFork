using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class AnonymousUser
    {
        public string AnonymousUserId { get; set; } = Guid.NewGuid().ToString();

        public List<SearchQuery> Items { get; set; }
    }
}