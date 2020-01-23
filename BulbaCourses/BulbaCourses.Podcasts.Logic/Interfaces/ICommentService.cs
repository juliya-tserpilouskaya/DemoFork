using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICommentService : IBaseService<CommentLogic>
    {
        Task<Result> AddAsync(CommentLogic comment);

        Task<Result<IEnumerable<CommentLogic>>> GetAllAsync(string courseId);

        Task<bool> ExistsIdAsync(string id);

        Task<Result<CommentLogic>> GetByIdAsync(string Id);
    }
}
