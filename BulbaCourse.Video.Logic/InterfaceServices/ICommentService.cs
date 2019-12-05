using BulbaCourse.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Logic.InterfaceServices
{
    public interface ICommentService
    {
        CommentLogic GetById(string commentId);
        IEnumerable<CommentLogic> GetAll();
        void Add(CommentLogic comment);
        ICollection<CommentLogic> GetCourseComments(int courseId);
        ICollection<CommentLogic> GetVideoComments(int videoId);
        CommentLogic UpdateCommentText(string commentId, string newText);
        void RemoveById(string commentId);
    }
}
