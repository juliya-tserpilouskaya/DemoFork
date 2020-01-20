using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;
using System.Threading.Tasks;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface ICoursesService : IDisposable
    {
        Task<Result<Course>> AddCourseAsync(CourseAdd_DTO model);

        Task<Course> GetCourseByIdAsync(string id);

        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task<Result<Course>> UpdateCourseAsync(Course model);

        Task<Result> DeleteCourseByIdAsync(string id);

        Task<bool> ExistCourseAsync(string title);

        Task<IEnumerable<Presentation>> GetAllPresentationsFromCourseAsync(string id);
    }
}
