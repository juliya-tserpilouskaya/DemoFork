using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Logic.Models
{
    public class CommentLogic
    {
        public string CommentId { get; set; }
        public string Text { get; set; }
        public UserLogic UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
