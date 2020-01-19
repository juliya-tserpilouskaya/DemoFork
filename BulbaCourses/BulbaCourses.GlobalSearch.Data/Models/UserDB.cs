using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class UserDB
    {
        public string Id { get; set; }
        public bool Authorization { get; set; }
        public ICollection<BookmarkDB> BookmarkItems { get; set; }
        public ICollection<SearchQueryDB> SearchQueryItems { get; set; }
    }
}
