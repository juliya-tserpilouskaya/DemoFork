using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface ICommentService
    {
        CommentInfo GetById(string commentId);
        IEnumerable<CommentInfo> GetAll();
        void Add(CommentInfo comment);
        void Update(CommentInfo comment);
        CommentInfo UpdateCommentText(string commentId, string newText);
        void Delete(CommentInfo comment);
        void DeleteById(string commentId);

        Task<CommentInfo> GetCommentByIdAsync(string commentId);
        Task<IEnumerable<CommentInfo>> GetAllAsync();
        Task<int> UpdateAsync(CommentInfo comment);
        Task<int> AddAsync(CommentInfo comment);
        Task<int> DeleteByIdAsync(string commentId);

    }
}
