using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class BookmarkDB
    {
        public string Id { get; set; } // = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string URL { get; set; } // +Escaping characters in database on Front
    }
}
