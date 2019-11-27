using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class CourseOwner : User
    {
        public List<string> ChannelList { get; set; }
        public List<Course> Courses { get; set; }
    }
}