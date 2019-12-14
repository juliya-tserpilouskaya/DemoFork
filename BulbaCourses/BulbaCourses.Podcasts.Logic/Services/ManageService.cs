using BulbaCourses.Podcasts.Logic.Services;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Tests")]

namespace BulbaCourses.Podcasts.Logic.Models
{
    internal class ManageService : IManageService
    {
        public Course Add(Course course)
        {
            if(course.Title == null || course.Author == null)
            {
                return null;
            }
            Course result = CourseStorage.Add(course);
            return result;
        }
        public void Delete(string id)
        {
            try
            {
                CourseStorage.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException();
            }
            
        }
        public Course Edit(Course course)
        {
           
            try
            {
                Course result = CourseStorage.Edit(course);
                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        public Course GetById(string id)
        {
            try
            {
                Course result = CourseStorage.GetCourse(id);
                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        } // change file reference to nothing if user don't own course. Only info
    }
}
