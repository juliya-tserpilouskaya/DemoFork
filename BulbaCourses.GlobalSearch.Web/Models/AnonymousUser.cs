using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class AnonymousUser
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        //public List<SearchQueries> Items { get; set; }
    }
}