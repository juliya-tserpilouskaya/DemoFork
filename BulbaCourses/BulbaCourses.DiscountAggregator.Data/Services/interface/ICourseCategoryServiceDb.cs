using BulbaCourses.DiscountAggregator.Data.Models;
using System.Collections.Generic;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseCategoryServiceDb
    {
        IEnumerable<CourseCategoryDb> GetAll();
        CourseCategoryDb GetById(string id);
        void Add(CourseCategoryDb courseDb);
        void Delete(CourseCategoryDb courseDb);
        void Update(CourseCategoryDb courseDb);
    }
}
