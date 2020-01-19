using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
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
        Task<IEnumerable<Course>> GetByIdCriteriaAsync(string idSearch);

        Task<Result<Course>> AddAsync(Course course);

        Task<Result> DeleteByIdAsync(string id);

        Task<Result<Course>> UpdateAsync(Course course);    
    }   
}
