using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CourseServices(IMapper mapper, ICourseService courseService)
        {
            this._mapper = mapper;
            _courseService = courseService;
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = _courseService.GetAll();
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<Course>>(courses);    
            return result;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _courseService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<Course>>(courses);
            return result;
        }

        public Course GetById(string id)
        {
            var courses = _courseService.GetById(id);
            var result = _mapper.Map<CourseDb, Course>(courses);
            return result;
        }

        public async Task<Course> GetByIdAsync(string id)
        {
            var courses = await _courseService.GetByIdAsync(id);
            var result = _mapper.Map<CourseDb, Course>(courses);
            return result;
        }

        public async Task<IEnumerable<Course>> GetByIdUserAsync(string idUser)
        {
            var courses = await _courseService.GetByIdUserAsync(idUser);
            var result = _mapper.Map<IEnumerable<Course>>(courses);
            return result;
        }

        public async Task<Result<Course>> AddAsync(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            course.Category.Id = Guid.NewGuid().ToString();
            course.Domain.Id = Guid.NewGuid().ToString();
            var courseDb = _mapper.Map<Course, CourseDb>(course);
            var result = await _courseService.AddAsync(courseDb);
            return result.IsSuccess ? Result<Course>.Ok(_mapper.Map<Course>(result.Data))
                : Result<Course>.Fail<Course>(result.Message);

        }

        public async Task<Result<Course>> DeleteByIdAsync(string id)
        {
            var result = await _courseService.DeleteByIdAsync(id);
            return result.IsSuccess ? Result<Course>.Ok(_mapper.Map<Course>(result.Data))
                : (Result<Course>)Result.Fail(result.Message);
        }

        public async Task<Result<Course>> UpdateAsync(Course course)
        {
            var courseDb = _mapper.Map<Course, CourseDb>(course);

            var result = await _courseService.UpdateAsync(courseDb);
            return result.IsSuccess ? Result<Course>.Ok(_mapper.Map<Course>(result.Data))
                : Result<Course>.Fail<Course>(result.Message);
        }

    }
}
