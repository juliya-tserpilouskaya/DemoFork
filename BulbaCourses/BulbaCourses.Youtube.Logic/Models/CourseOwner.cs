using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Logic.Models
{
    public class CourseOwner : User
    {
        public IEnumerable<Channel> ChannelList { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}