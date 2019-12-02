using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class Comment
    {
        public string CommentId { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
