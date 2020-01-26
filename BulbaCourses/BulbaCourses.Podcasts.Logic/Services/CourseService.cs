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
        private readonly IManager<UserDb> UdbManager;

        public CourseService(IMapper mapper, IManager<CourseDb> dbmanager, IManager<UserDb> userM)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
            this.UdbManager = userM;
        }

        public async Task<Result> AddAsync(CourseLogic course, UserLogic user)
        {
            try
            {
                course.Id = Guid.NewGuid().ToString();
                course.Author = user;
                course.CreationDate = DateTime.Now;
                course.Raiting = null;
                course.Duration = course.Audios.Aggregate(0, (x,y) => x + y.Duration);
                user.UploadedCourses.Add(course);
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                await UdbManager.UpdateAsync(userDb);
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
                var course = (await dbmanager.GetAllAsync("")).Where(c => c.Name.Contains(Name)).ToList();
                var courseLogic = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(course);
                return Result<IEnumerable<CourseLogic>>.Ok(courseLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<CourseLogic>>> GetAllAsync(string filter)
        {
            try
            {
                var courses = await dbmanager.GetAllAsync(filter);
                var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
                return Result<IEnumerable<CourseLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }
        
        public Result DeleteAsync(CourseLogic course, UserLogic user)
        {
            
            try
            {
                if (user.UploadedCourses.Contains(course) || user.IsAdmin)
                {
                    var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                    dbmanager.RemoveAsync(courseDb);
                    return Result.Ok(); 
                }
                else
                {
                    return Result.Fail("Unathorized");
                }
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

        public async Task<Result> UpdateAsync(CourseLogic course, UserLogic user)
        {
            try
            {
                if (user.UploadedCourses.Contains(course) || user.IsAdmin)
                {
                    var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                    await dbmanager.UpdateAsync(courseDb);
                    return Result.Ok();
                }
                else
                {
                    return Result.Fail("Unathorized");
                }
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

        public async Task<bool> ExistsNameAsync(string name)
        {
            return await dbmanager.ExistNameAsync(name);
        }

        public async Task<bool> ExistsIdAsync(string id)
        {
            return await dbmanager.ExistIdAsync(id);
        }

        public async Task<Result> BuyAsync(CourseLogic courselogic, UserLogic userId)
        {
            try
            {
                userId.BoughtCourses.Add(courselogic);
                var userDb = mapper.Map<UserLogic, UserDb>(userId);
                await UdbManager.UpdateAsync(userDb);
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
    }
}
