using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Ninject;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        private readonly IManager<CourseDb> dbmanager;

        public CourseService(IMapper mapper, IManager<CourseDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<Result> AddAsync(CourseLogic course)
        {
            try
            {
                course.Id = Guid.NewGuid().ToString();
                course.CreationDate = DateTime.Now;
                course.Raiting = null;
                course.Duration = course.Audios.Aggregate(0, (x,y) => x + y.Duration);
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                var result = await dbmanager.AddAsync(courseDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
            
        }

        public async Task<Result<CourseLogic>> GetByIdAsync(string id)
        {
            try
            {
                var course = await dbmanager.GetByIdAsync(id);
                var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
                return Result<CourseLogic>.Ok(CourseLogic);
            }
            catch (Exception)
            {
                return Result<CourseLogic>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<CourseLogic>>> SearchAsync(string Name)
        {
            try
            {
                var course = (await dbmanager.GetAllAsync()).Where(c => c.Name.Contains(Name)).ToList();
                var courseLogic = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(course);
                return Result<IEnumerable<CourseLogic>>.Ok(courseLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<CourseLogic>>> GetAllAsync()
        {
            try
            {
                var courses = await dbmanager.GetAllAsync();
                var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
                return Result<IEnumerable<CourseLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }
        
        public async Task<Result> DeleteAsync(CourseLogic course)
        {
            
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                await dbmanager.RemoveAsync(courseDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(CourseLogic course)
        {
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                await dbmanager.UpdateAsync(courseDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await dbmanager.ExistAsync(name);
        }
    }
}
