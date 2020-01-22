using BulbaCourses.Podcasts.Logic.Services;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Tests")]

namespace BulbaCourses.Podcasts.Logic.Models
{
    public enum OwnershipType { None, Bought, Uploaded, Admin }
    internal class ManageService : IManageService
    {
        public Course Add(Course course)
        {
            if (CheckOwnership(course.Id) != OwnershipType.None)
            {
                if (course.Title == null || course.Author == null)
                {
                    return null;
                }
                Course result = CourseStorage.Add(course);
                return result;
            }
            else
            {
                throw new AccessViolationException();
            }
        }// add check for authorization
        public void Delete(Course course)
        {
            if (CheckOwnership(course.Id) != OwnershipType.None)
            {
                CourseStorage.Delete(course);
            }
            else
            {
                throw new AccessViolationException();
            }

        }// add check for authorization
        public Course Edit(Course course)// add check for authorization
        {
            if (CheckOwnership(course.Id) != OwnershipType.None)
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
            else
            {
                throw new AccessViolationException();
            }
        }
        public Course GetById(string id)
        {
            if (CheckOwnership(id) != OwnershipType.None)
            {
                try
                {
                    return CourseStorage.GetCourse(id);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }
            else
            {
                throw new AccessViolationException();
            }
        }

        private OwnershipType CheckOwnership(string courseId) // need to check for user id
        {
            try
            {
                Account _user = AccountStorage.GetAccount("0"); //temporarily 0
                return _user.CheckOwnership(courseId);
            }
            catch (IndexOutOfRangeException)
            {
                return OwnershipType.None;
            }
        }

        public CourseInfo GetCourseInfo(string id)
        {
            try
            {
                Course result = GetById(id);
                if (result != null)
                {
                    return CourseStorage.GetCourseInfo(result); 
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
    }
}
