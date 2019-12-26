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
        public void AddCourse(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            dbmanager.AddCourse(courseDb);
        }

        public void AddDiscription(string Id, string description)
        {
            var course = dbmanager.GetCourseById(Id);
            course.Description = description;
            dbmanager.UpdateCourse(course);

        }

        public void AddFileToCourse(string Id, AudioLogic audio)
        {
            var audiodb = mapper.Map<AudioLogic, AudioDb>(audio);
            var courseAudios = dbmanager.GetCourseById(Id).Audios;
            courseAudios.Add(audiodb);
        }

        public CourseLogic GetById(string Id)
        {
            var course = dbmanager.GetCourseById(Id);
            var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
            return CourseLogic;
        }

        public CourseLogic GetCourseByName(string courseName)
        {
            var course = dbmanager.GetAllCourses().FirstOrDefault(c => c.Name.Equals(courseName));
            var CourseLogic = mapper.Map<CourseDb, CourseLogic>(course);
            return CourseLogic;
        }

        public IEnumerable<CourseLogic> GetAll()
        {
            var courses = dbmanager.GetAllCourses();
            var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseLogic>>(courses);
            return result;
        }

        public void Delete(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            dbmanager.RemoveCourse(courseDb);
        }
        public void Update(CourseLogic course)
        {
            var courseDb = mapper.Map<CourseLogic, CourseDb>(course);
            dbmanager.UpdateCourse(courseDb);
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
            var commentDb = course.Comments.ToList().AsReadOnly();
            var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentLogic>>(commentDb);
            return result;
        }
    }
}
