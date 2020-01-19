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
        Task<Result> Add(CommentLogic comment, CourseLogic course);

        Task<Result<IEnumerable<CommentLogic>>> GetAll();

        Task<bool> Exists(string id);
    }
}
