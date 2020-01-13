using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public bool Authorization { get; set; }
        public ICollection<BookmarkDTO> BookmarkItems { get; set; }
        public ICollection<SearchQueryDTO> SearchQueryItems { get; set; }
    }
}
