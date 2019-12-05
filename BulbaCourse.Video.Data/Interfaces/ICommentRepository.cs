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
        CommentDb GetById(string commentId);
        IEnumerable<CommentDb> GetAll();
        void Add(CommentDb comment);
        void Update(CommentDb comment);
        void RemoveById(string commentId);
        void Remove(CommentDb comment);
        ICollection<CommentDb> GetCourseComments(int courseId);
        ICollection<CommentDb> GetVideoComments(int videoId);
        CommentDb UpdateCommentText(string commentId, string newText);
    }
}
