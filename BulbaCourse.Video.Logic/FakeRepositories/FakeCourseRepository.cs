using BulbaCourse.Video.Data.Enums;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.FakeRepositories
{
    public  class FakeCourseRepository: ICourseRepository
    {
        private List<Course> _courses;

        public FakeCourseRepository()
        {
            _courses = new List<Course>() 
            {
               new Course() 
               { 
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_1",
                   CreatorId = "Creator_1",
                   Level = CourseLevel.Beginner
               },

               new Course()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_2",
                   CreatorId = "Creator_2",
                   Level = CourseLevel.Beginner
               }, 
               new Course()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_3",
                   CreatorId = "Creator_3",
                   Level = CourseLevel.Advanced
               },
            };
        }

        public Course AddCourse(Course course)
        {
            _courses.Add(course);
            return course;
        }

        public bool AddDiscription(string courseId, string discription)
        {
            throw new NotImplementedException();
        }

        public bool AddVideoToCourse(string courseId, string videoId)
        {
            throw new NotImplementedException();
        }

        public Tag CheckTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return _courses.ToList();
        }

        public Course GetCourseById(string courseId)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseByName(string courseName)
        {
            throw new NotImplementedException();
        }

        public CourseLevel GetCourseLevel(string courseId)
        {
            throw new NotImplementedException();
        }

        public ICollection<VideoMaterial> GetCourseVideos(string courseId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetTags(string courseId)
        {
            throw new NotImplementedException();
        }

        public VideoMaterial GetVideoByOrder(string courseId, int videoOrder)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourseLevel(string courseId, CourseLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
