using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.InterfaceServices
{
    public interface ICommentService
    {
        CommentDb GetById(string commentId);
        IEnumerable<CommentDb> GetAll();
        void Add(CommentDb comment);
        ICollection<CommentDb> GetCourseComments(int courseId);
        ICollection<CommentDb> GetVideoComments(int videoId);
        CommentDb UpdateCommentText(string commentId, string newText);
        void RemoveById(string commentId);
    }
}
