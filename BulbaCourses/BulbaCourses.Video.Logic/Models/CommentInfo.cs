using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Models
{
    public class CommentInfo
    {
        public string CommentId { get; set; }
        public string Text { get; set; }
        public UserInfo UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
