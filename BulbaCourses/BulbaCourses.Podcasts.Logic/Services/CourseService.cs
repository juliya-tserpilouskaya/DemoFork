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

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        private readonly IManager dbmanager;

        public CourseService(IMapper mapper, IManager dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<Result> Add(CourseLogic course)
        {
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                var result = await dbmanager.Add(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
            
        }

        public async Task<Result<AudioLogic>> AddFileToCourse(string Id, AudioLogic audio)
        {
            try
            {
                var audiodb = mapper.Map<AudioLogic, AudioDb>(audio);
                var courseAudios = await dbmanager.GetById(Id).Audios;
                courseAudios.Add(audiodb);
                return Result<AudioLogic>.Ok(audio);
            }
            catch (Exception)
            {
                return Result<AudioLogic>.Fail("Exception");
            }
        }

        public async Task<Result<CourseLogic>> GetById(string Id)
        {
            try
            {
                var course = await dbmanager.GetById(Id);
                var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
                return Result<CourseLogic>.Ok(CourseLogic);
            }
            catch (Exception)
            {
                return Result<CourseLogic>.Fail("Exception");
            }
        }

        public async Task<Result<CourseLogic>> GetByName(string courseName)
        {
            try
            {
                var course = await dbmanager.GetAll().FirstOrDefault(c => c.Name.Equals(courseName));
                var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
                return Result<CourseLogic>.Ok(CourseLogic);
            }
            catch (Exception)
            {
                return Result<CourseLogic>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<CourseLogic>>> GetAll()
        {
            try
            {
                var courses = await dbmanager.GetAll();
                var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
                return Result<IEnumerable<CourseLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CourseLogic>>.Fail("Exception");
            }
        }
        
        public async Task<Result> Delete(CourseLogic course)
        {
            
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                await dbmanager.Remove(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> Update(CourseLogic course)
        {
            try
            {
                var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
                await dbmanager.Update(courseDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAll().Any(b => b.Name == name);
        }
    }
}
