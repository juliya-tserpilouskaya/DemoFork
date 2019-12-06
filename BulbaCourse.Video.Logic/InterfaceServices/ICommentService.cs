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
        IEnumerable<CommentDb> GetCourseComments(int courseId);
        IEnumerable<CommentDb> GetVideoComments(int videoId);
        CommentDb UpdateCommentText(string commentId, string newText);
        void RemoveById(string commentId);
    }
}
