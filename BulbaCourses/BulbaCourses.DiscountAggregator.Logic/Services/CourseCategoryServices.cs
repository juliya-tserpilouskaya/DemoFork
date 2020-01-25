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
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
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
            courseCategory.Id = Guid.NewGuid().ToString();
            var courseCategoryDb = _mapper.Map<CourseCategory, CourseCategoryDb>(courseCategory);
            var result = await _courseCategoryServiceDb.AddAsync(courseCategoryDb);
            return result.IsSuccess ? Result<CourseCategory>.Ok(_mapper.Map<CourseCategory>(result.Data))
                 : Result<CourseCategory>.Fail<CourseCategory>(result.Message);
        }

        public async Task<Result<CourseCategory>> DeleteByIdAsync(string id)
        {
            var result = await _courseCategoryServiceDb.DeleteByIdAsync(id);
            return result.IsSuccess ? Result<CourseCategory>.Ok(_mapper.Map<CourseCategory>(result.Data))
                 : Result<CourseCategory>.Fail<CourseCategory>(result.Message);
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
            var result = await _courseCategoryServiceDb.UpdateAsync(categoryDb);
            return result.IsSuccess ? Result<CourseCategory>.Ok(_mapper.Map<CourseCategory>(result.Data))
                : Result<CourseCategory>.Fail<CourseCategory>(result.Message);
        }
    }
}
