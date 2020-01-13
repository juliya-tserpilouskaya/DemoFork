using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
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

        public async Task<Result<Course>> AddAsync(Course course)
        {
            var courseDb = _mapper.Map<Course, CourseDb>(course);

            try
            {
                await _courseService.AddAsync(courseDb);
                return Result<CourseDb>.Ok(_mapper.Map<Course>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Course>)Result<Course>.Fail<Course>($"Cannot save course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<Course>)Result<Course>.Fail<Course>($"Cannot save course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Course>)Result<Course>.Fail<Course>($"Invalid course. {e.Message}");
            }
        }

        public Task<Result> DeleteByIdAsync(string id)
        {
            _courseService.DeleteByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }

        public async Task<Result<Course>> UpdateAsync(Course course)
        {
            var courseDb = _mapper.Map<Course, CourseDb>(course);
            try
            {
                await _courseService.UpdateAsync(courseDb);
                return Result<CourseDb>.Ok(_mapper.Map<Course>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Course>)Result<Course>.Fail<Course>($"Cannot save course. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Course>)Result<Course>.Fail<Course>($"Invalid course. {e.Message}");
            }
        }
    }
}
