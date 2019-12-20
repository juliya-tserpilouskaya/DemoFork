using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseServices
    {
        Course GetById(string id);
        IEnumerable<Course> GetAll();
        void Add(Course course);
        void Delete(Course course);
        void Update(Course course);
    }   
}
