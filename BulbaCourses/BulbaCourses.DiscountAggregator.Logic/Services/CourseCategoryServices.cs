using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class CourseCategoryServices : ICourseCategoryServices
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryServiceDb _courseCategoryServiceDb;

        public CourseCategoryServices(IMapper mapper, ICourseCategoryServiceDb courseCategoryServiceDb)
        {
            this._mapper = mapper;
            _courseCategoryServiceDb = courseCategoryServiceDb;
        }

        public async Task<Result<CourseCategory>> AddAsync(CourseCategory courseCategory)
        {
            var courseCategoryDb = _mapper.Map<CourseCategory, CourseCategoryDb>(courseCategory);

            try
            {
                await _courseCategoryServiceDb.AddAsync(courseCategoryDb);
                return Result<CourseCategoryDb>.Ok(_mapper.Map<CourseCategory>(courseCategoryDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Cannot save category. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Cannot save category. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Invalid category. {e.Message}");
            }
        }

        public Task<Result> DeleteByIdAsync(string id)
        {
            _courseCategoryServiceDb.DeleteByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }

        public async Task<IEnumerable<CourseCategory>> GetAllAsync()
        {
            var categories = await _courseCategoryServiceDb.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CourseCategoryDb>, IEnumerable<CourseCategory>>(categories);
            return result;
        }

        public async Task<CourseCategory> GetByIdAsync(string id)
        {
            var categories = await _courseCategoryServiceDb.GetByIdAsync(id);
            var result = _mapper.Map<CourseCategoryDb, CourseCategory>(categories);
            return result;
        }

        public async Task<Result<CourseCategory>> UpdateAsync(CourseCategory category)
        {
            var categoryDb = _mapper.Map<CourseCategory, CourseCategoryDb>(category);
            try
            {
                await _courseCategoryServiceDb.UpdateAsync(categoryDb);
                return Result<CourseDb>.Ok(_mapper.Map<CourseCategory>(categoryDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Cannot save category. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Cannot save category. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseCategory>)Result<CourseCategory>.Fail<CourseCategory>($"Invalid category. {e.Message}");
            }
        }
    }
}
