using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface IAuthorService
    {
        Task<AuthorInfo> GetByIdAsync(string authorId);
        Task<IEnumerable<AuthorInfo>> GetAllAsync();
        Task<Result<AuthorInfo>> UpdateAsync(AuthorInfo author);
        Task<Result<AuthorInfo>> AddAsync(AuthorInfo author);
        Task<Result> DeleteByIdAsync(string authorId);
        Task<Result> DeleteAsync(AuthorInfo author);

        IEnumerable<CourseInfo> GetAllCourses(AuthorInfo author);
    }
}
