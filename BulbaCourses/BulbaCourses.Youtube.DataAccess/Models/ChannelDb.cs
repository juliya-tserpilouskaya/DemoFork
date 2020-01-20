using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class ChannelDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<ResultVideoDb> Videos { get; set; } //reference
    }
}