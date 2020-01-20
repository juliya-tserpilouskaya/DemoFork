using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using Fody;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Repositories;
using BulbaCourses.TextMaterials_Presentations.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Presentations.Logic.Models;

[assembly: ConfigureAwait(false)]

namespace Presentations.Logic.Services
{
    public class CourseService : ICoursesService
    {
        private IUnitOfWorkRepository _uow;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Map CourseAdd_DTO to CourseDB, passes to Add DB-method the CourseDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Course>> AddCourseAsync(CourseAdd_DTO model)
        {
            var courseDb = _mapper.Map<CourseAdd_DTO, CourseDB>(model);
            _uow.Courses.Add(courseDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Course>.Ok(_mapper.Map<Course>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Course>)Result<Course>.Fail("Cannot save model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Course>)Result<Course>.Fail($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Course>)Result<Course>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Map CourseDB to Course, passes to GetByIdAsync DB-method the id for getting course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Course> GetCourseByIdAsync(string id)
        {
            var course = await _uow.Courses.GetByIdAsync(id);
            return _mapper.Map<CourseDB, Course>(course);
        }

        /// <summary>
        /// Map CourseDB to Course, get all courses from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var courses = await _uow.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDB>, IEnumerable<Course>>(courses);
        }

        /// <summary>
        /// Map Course to CourseDB, passes to Update DB-method the CourseDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Course>> UpdateCourseAsync(Course model)
        {
            var courseDb = _mapper.Map<Course, CourseDB>(model);
            _uow.Courses.Update(courseDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Course>.Ok(_mapper.Map<Course>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Course>)Result<Course>.Fail("Cannot update model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Course>)Result<Course>.Fail($"Cannot update model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Course>)Result<Course>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion CourseDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> DeleteCourseByIdAsync(string id)
        {
            _uow.Courses.DeleteById(id);

            try
            {
                await _uow.SaveAsync();
                return await Task.FromResult(Result.Ok());
            }
            catch (DbUpdateConcurrencyException e)
            {
                return await Task.FromResult(Result.Fail("Cannot delete model"));
            }
            catch (DbUpdateException e)
            {
                return await Task.FromResult(Result.Fail($"Cannot delete model. Duplicate field. {e.Message}"));
            }
            catch (DbEntityValidationException e)
            {
                return await Task.FromResult(Result.Fail("Invalid id"));
            }
        }

        /// <summary>
        /// Checks exist the same title in the database or not
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> ExistCourseAsync(string title)
        {
            return await _uow.Context.Courses.AnyAsync(b => b.Name == title);
        }

        public async Task<IEnumerable<Presentation>> GetAllPresentationsFromCourseAsync(string id)
        {
            var course = await _uow.CourseLoading.GetAllPresentationsFromCourseAsync(id);
            return _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>(course.CoursePresentations);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
