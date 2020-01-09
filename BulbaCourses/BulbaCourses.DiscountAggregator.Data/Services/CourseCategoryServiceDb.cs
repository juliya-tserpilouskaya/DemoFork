using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseCategoryServiceDb
    {
        private readonly CourseContext context;

        public CourseCategoryServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public void Add(CourseCategoryDb category)
        {
            context.CourseCategories.Add(category);
            context.SaveChanges();
        }

        public IEnumerable<CourseCategoryDb> GetAll()
        {
            var categories = context.CourseCategories.ToList().AsReadOnly();
            return categories;
        }

        public CourseCategoryDb GetById(string id)
        {
            var category = context.CourseCategories.FirstOrDefault(c => c.Id.Equals(id));
            return category;
        }

        public void Delete(CourseCategoryDb category)
        {
            context.CourseCategories.Remove(category);
            context.SaveChanges();
        }

        public void Update(CourseCategoryDb category)
        {
            if (category != null)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
