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
        private List<CourseDb> _courses;

        public FakeCourseRepository()
        {
            _courses = new List<CourseDb>() 
            {
               new CourseDb() 
               { 
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_1",
                   CreatorId = "Creator_1",
                   Level = CourseLevel.Beginner
               },

               new CourseDb()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_2",
                   CreatorId = "Creator_2",
                   Level = CourseLevel.Beginner
               }, 
               new CourseDb()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_3",
                   CreatorId = "Creator_3",
                   Level = CourseLevel.Advanced
               },
            };
        }

        public CourseDb AddCourse(CourseDb course)
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

        public TagDb CheckTag(TagDb tag)
        {
            throw new NotImplementedException();
        }

        public void Delete(CourseDb course)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDb> GetAll()
        {
            return _courses.ToList();
        }

        public CourseDb GetCourseById(string courseId)
        {
            throw new NotImplementedException();
        }

        public CourseDb GetCourseByName(string courseName)
        {
            throw new NotImplementedException();
        }

        public CourseLevel GetCourseLevel(string courseId)
        {
            throw new NotImplementedException();
        }

        public ICollection<VideoMaterialDb> GetCourseVideos(string courseId)
        {
            throw new NotImplementedException();
        }

        public ICollection<TagDb> GetTags(string courseId)
        {
            throw new NotImplementedException();
        }

        public VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourseLevel(string courseId, CourseLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
