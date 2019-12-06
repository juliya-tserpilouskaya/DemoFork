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
        void Remove(CommentDb comment);
    }
}
