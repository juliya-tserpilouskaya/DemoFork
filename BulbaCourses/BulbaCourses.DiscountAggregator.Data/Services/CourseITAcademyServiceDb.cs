using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseITAcademyServiceDb : ICourseITAcademyServiceDb
    {
        private readonly DAContext context;

        public CourseITAcademyServiceDb(DAContext service)
        {
            this.context = service;
        }

        public async Task<Result<IEnumerable<CourseDb>>> AddRangeAsync(IEnumerable<CourseDb> coursesDb)
        {
            try
            {
                List<CourseDb> listAddCourses = new List<CourseDb>();
                List<CourseDb> listUpdateCourses = new List<CourseDb>();
                CourseDb courseUpd;
                DomainDb domain;
                CourseCategoryDb category;
                foreach (var courseNew in coursesDb)
                {
                    courseUpd = context.Courses
                        .FirstOrDefault(x => x.URL == courseNew.URL);
                    if (courseUpd == null)
                    {
                        courseNew.Id = Guid.NewGuid().ToString();
                        domain = context.Domains.FirstOrDefault(x => x.DomainURL == courseNew.Domain.DomainURL);
                        if (domain != null)
                            courseNew.Domain = domain;
                        else
                            courseNew.Domain = await CreateDomainDbAsync(courseNew.Domain);

                        category = context.CourseCategories.FirstOrDefault(x => x.Name == courseNew.Category.Name);
                        if (category != null)
                            courseNew.Category = category;
                        else
                            courseNew.Category = await CreateCategoryDbAsync(courseNew.Category);

                        listAddCourses.Add(courseNew);
                    }
                    else
                    {
                        if (courseUpd.OldPrice != courseNew.Price)
                        {
                            courseUpd.DateOldPrice = DateTime.Now;
                            courseUpd.OldPrice = courseUpd.Price;
                            courseUpd.Price = courseNew.Price;
                            courseUpd.Discount = courseNew.Discount;
                        }
                        courseUpd.DateStartCourse = courseNew.DateStartCourse;
                        if (courseNew.Category != null && courseUpd.Category != null
                            && courseUpd.Category.Name != courseNew.Category.Name) 
                            courseUpd.Category = courseNew.Category;
                        courseUpd.Description = courseNew.Description;
                        if (courseNew.Domain != null && courseUpd.Domain != null 
                            &&  courseUpd.Domain.DomainURL != courseNew.Domain.DomainURL)
                            courseUpd.Domain = courseNew.Domain;
                        courseUpd.DateChange = DateTime.Now;
                        context.Entry(courseUpd).State = EntityState.Modified;
                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                }

                context.Courses.AddRange(listAddCourses);
                await context.SaveChangesAsync().ConfigureAwait(false);
                
                return Result<IEnumerable<CourseDb>>.Ok(coursesDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<IEnumerable<CourseDb>>.Fail<IEnumerable<CourseDb>>($"Cannot save course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result< IEnumerable<CourseDb>>)Result< IEnumerable<CourseDb>>.Fail< IEnumerable<CourseDb>>($"Cannot save course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result< IEnumerable<CourseDb>>)Result< IEnumerable<CourseDb>>.Fail< IEnumerable<CourseDb>>($"Invalid course. {e.Message}");
            }
        }

        private async Task<DomainDb> CreateDomainDbAsync(DomainDb domain)
        {
            context.Domains.Add(domain);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return context.Domains.FirstOrDefault(x => x.DomainURL == domain.DomainURL);
        }

        private async Task<CourseCategoryDb> CreateCategoryDbAsync(CourseCategoryDb category)
        {
            context.CourseCategories.Add(category);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return context.CourseCategories.FirstOrDefault(x => x.Name == category.Name);
        }
    }
}
