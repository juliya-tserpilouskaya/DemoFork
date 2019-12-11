using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface ICourseRepository
    {
        CourseDb GetById(string courseId);
        IEnumerable<CourseDb> GetAll();
        void Add(CourseDb course);
        void Update(CourseDb course);
        void Remove(CourseDb course);
    }
}
