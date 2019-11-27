using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class CourseOwner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<string> ChannelList { get; set; }
        public List<Course> Courses { get; set; }
    }
}