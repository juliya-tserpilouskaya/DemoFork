using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface ICourseRepository : IDisposable
    {
        CourseDb GetById(string courseId);
        IEnumerable<CourseDb> GetAll();
        void Add(CourseDb course);
        void Update(CourseDb course);
        void Remove(CourseDb course);

        Task<CourseDb> GetByIdAsync(string courseId);
        Task<IEnumerable<CourseDb>> GetAllAsync();
        Task<CourseDb> AddAsync(CourseDb courseDb);
        Task<CourseDb> UpdateAsync(CourseDb courseDb);
        Task RemoveAsync(CourseDb course);
        Task RemoveAsyncById(string courseId);

        Task<bool> IsNameExistAsync(string courseName);
    }
}
