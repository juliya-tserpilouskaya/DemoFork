using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly VideoDbContext videoDbContext;

        public CourseRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }

        public void Add(CourseDb course)
        {
            videoDbContext.Courses.Add(course);
            videoDbContext.SaveChanges();

        }

        public IEnumerable<CourseDb> GetAll()
        {
            var courseList = videoDbContext.Courses.ToList().AsReadOnly();
            return courseList;

        }

        public CourseDb GetById(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            return course;

        }

        public void Remove(CourseDb course)
        {
            videoDbContext.Courses.Remove(course);
            videoDbContext.SaveChanges();

        }

        public void Update(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            videoDbContext.Entry(course).State = EntityState.Modified;
            videoDbContext.SaveChanges();

        }
    }
}
