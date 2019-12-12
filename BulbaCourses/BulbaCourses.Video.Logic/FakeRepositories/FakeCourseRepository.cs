using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.FakeRepositories
{
    public class FakeCourseRepository : ICourseRepository
    {
        private List<CourseDb> _courses;
        public FakeCourseRepository()
        {
            UserDb user1 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user1",
                Password = "1111",
                Email = "1@gmail.com"
            };
            UserDb user2 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user2",
                Password = "2222",
                Email = "3@gmail.com"
            };

            UserDb user3 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user3",
                Password = "3333",
                Email = "3@gmail.com"
            };

            _courses = new List<CourseDb>()
            {
               new CourseDb()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_1",
                   Author = user1,
                   Level = 1
               },

               new CourseDb()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_2",
                   Author = user2,
                   Level = 1
               },
               new CourseDb()
               {
                   CourseId = Guid.NewGuid().ToString(),
                   Name = "Course_3",
                   Author = user3,
                   Level = 3
               },
            };
        }

        public void Add(CourseDb course)
        {
            _courses.Add(course);
        }

        public IEnumerable<CourseDb> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseDb GetById(string courseId)
        {
            throw new NotImplementedException();
        }

        public void Remove(CourseDb course)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseDb course)
        {
            throw new NotImplementedException();
        }
    }
}
