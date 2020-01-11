using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class SearchQueryDB
    {
        public string Id { get; set; } // = Guid.NewGuid().ToString();
        public string Query { get; set; }
        public DateTime? Created { get; set; }
        public string UserId { get; set; }
    }
}
