using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class CourseOwner : User
    {
        public IEnumerable<string> ChannelList { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}