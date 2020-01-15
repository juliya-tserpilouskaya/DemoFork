using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseCategoryServices<T> : IDisposable where T : class
    {
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result<T>> GetByIdAsync(string id);
        Task <Result> AddAsync(T course);
        Task<Result> DeleteByIdAsync(string id);
        Task<Result> UpdateAsync(T course);
    }
}
