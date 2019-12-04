using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface ICommentRepository
    {
        Comment AddComment(Comment comment);
        ICollection<Comment> GetCourseComments(int courseId);
        ICollection<Comment> GetVideoComments(int videoId);
        Comment UpdateCommentText(string commentId, string newText);
        bool RemoveById(int commentId);
    }
}
