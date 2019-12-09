using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Mentor : User
    {
        public IEnumerable<Channel> ChannelList { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}