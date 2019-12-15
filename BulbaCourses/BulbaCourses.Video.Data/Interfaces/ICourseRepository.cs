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
    }
}
