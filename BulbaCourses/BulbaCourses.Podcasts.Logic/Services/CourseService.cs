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

        public Result Add(CourseLogic course)
        {
            try
            {
                course.Id = Guid.NewGuid().ToString();
                course.CreationDate = DateTime.Now;
                course.Raiting = null;
                course.Duration = course.Audios.Aggregate(0, (x,y) => x + y.Duration);
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                var result = dbmanager.AddAsync(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
            
        }

        public Result<CourseLogic> GetById(string Id)
        {
            try
            {
                var course = dbmanager.GetByIdAsync(Id).GetAwaiter().GetResult();
                var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
                return Result<CourseLogic>.Ok(CourseLogic);
            }
            catch (Exception)
            {
                return Result<CourseLogic>.Fail("Exception");
            }
        }

        public Result<IEnumerable<CourseLogic>> Search(string Name)
        {
            try
            {
                var course = dbmanager.GetAllAsync().GetAwaiter().GetResult().Where(c => c.Name.Contains(Name)).ToList();
                var CourseLogic = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(course);
                return Result<IEnumerable<CourseLogic>>.Ok(CourseLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }

        public Result<IEnumerable<CourseLogic>> GetAll()
        {
            try
            {
                var courses = dbmanager.GetAllAsync().GetAwaiter().GetResult();
                var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
                return Result<IEnumerable<CourseLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }
        
        public Result Delete(CourseLogic course)
        {
            
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                dbmanager.RemoveAsync(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public Result Update(CourseLogic course)
        {
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                dbmanager.UpdateAsync(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAllAsync().GetAwaiter().GetResult().Any(b => b.Name == name);
        }
    }
}
