using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class CommentDb
    {
        public string CommentId { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public UserDb UserId { get; set; }
        public VideoMaterialDb VideoId { get; set; }
        public DateTime Date { get; set; }
    }
}
