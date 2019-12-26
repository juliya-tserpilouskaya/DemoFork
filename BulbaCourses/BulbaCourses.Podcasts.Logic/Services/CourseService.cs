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
        private readonly IDBManager dbmanager;

        public CourseService(IMapper mapper, IDBManager dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<CourseLogic> AddCourse(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            var result = await dbmanager.AddCourse(courseDb);
            return result;
        }

        public void AddDiscription(string Id, string description)
        {
            var course = dbmanager.GetCourseById(Id);
            course.Description = description;
            dbmanager.UpdateCourse(course);

        }

        public AudioLogic AddFileToCourse(string Id, AudioLogic audio)
        {
            var audiodb = mapper.Map<AudioLogic, AudioDb>(audio);
            var courseAudios = dbmanager.GetCourseById(Id).Audios;
            courseAudios.Add(audiodb);
            return audio;
        }

        public async Task<CourseLogic> GetById(string Id)
        {
            var course = await dbmanager.GetCourseById(Id);
            var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
            return CourseLogic;
        }

        public CourseLogic GetCourseByName(string courseName)
        {
            var course = Task.FromResult(dbmanager.GetAllCourses().FirstOrDefault(c => c.Name.Equals(courseName))).Result;
            var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
            return CourseLogic;
        }

        public async Task<IEnumerable<CourseLogic>> GetAll()
        {
            var courses = await dbmanager.GetAllCourses();
            var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
            return result;
        } //debug

        public void Delete(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            dbmanager.RemoveCourse(courseDb);
        }

        public async Task<CourseLogic> Update(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            var result = await dbmanager.UpdateCourse(courseDb);
            return result;
        }

        public IEnumerable<AudioLogic> GetCourseAudios(string Id)
        {
            var course = dbmanager.GetCourseById(Id);
            var audiodb = course.Audios.ToList().AsReadOnly();
            var result = mapper.Map<IEnumerable<AudioDb>, IEnumerable<AudioLogic>>(audiodb);
            return result;
        }

        public IEnumerable<CommentLogic> GetCourseComments(string Id)
        {
            var course = dbmanager.GetCourseById(Id);
            IEnumerable<CommentDb> comments = new List<CommentDb>();
            foreach (AudioDb audio in course.Audios)
            {
                foreach (CommentDb comment in audio.Comments)
                {
                    comments.Append<CommentDb>(comment);
                }
            }
            var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentLogic>>(comments);
            return result;
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAllCourses().Any(b => b.Name == name);

        }
    }
}
