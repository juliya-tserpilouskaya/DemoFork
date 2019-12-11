using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    public class CommentView
    {
        public string CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}