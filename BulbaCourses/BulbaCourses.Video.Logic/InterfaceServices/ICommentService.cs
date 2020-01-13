using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
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
        void Delete(CommentInfo comment);
        void DeleteById(string commentId);
        CommentInfo UpdateCommentText(string commentId, string newText);

        Task<CommentInfo> GetCommentByIdAsync(string commentId);
        Task<IEnumerable<CommentInfo>> GetAllAsync();
        Task<Result<CommentInfo>> UpdateAsync(CommentInfo comment);
        Task<Result<CommentInfo>> AddAsync(CommentInfo comment);
        Task<Result> DeleteByIdAsync(string commentId);

    }
}
