using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseService
    {
        IEnumerable<CourseDb> GetAll();
        CourseDb GetById(string id);
        void Add(CourseDb course);
        void Delete(CourseDb course);
        void Update(CourseDb course);
        
    }
}
