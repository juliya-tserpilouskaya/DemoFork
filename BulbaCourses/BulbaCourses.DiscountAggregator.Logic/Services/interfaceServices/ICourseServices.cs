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
        IEnumerable<Course> GetAll();

        Task<IEnumerable<Course>> GetAllAsync();

        Course GetById(string id);

        Task<Course> GetByIdAsync(string id);

        void Add(Course course);

        void DeleteById(string id);

        void Update(Course course);

    }   
}
