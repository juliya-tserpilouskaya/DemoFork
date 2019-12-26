using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Data.Manager
{
    class DBManager : IDBManager
    {
        public void AddComment(CommentDb commentDb)
        {
            throw new NotImplementedException();
        }

        public void AddCourse(CourseDb courseDb)
        {
            throw new NotImplementedException();
        }

        public void AddUser(UserDb userDb)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDb> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDb> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDb> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public CommentDb GetCommentById(string id)
        {
            throw new NotImplementedException();
        }

        public CourseDb GetCourseById(string id)
        {
            throw new NotImplementedException();
        }

        public UserDb GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(CommentDb commentDb)
        {
            throw new NotImplementedException();
        }

        public void RemoveCourse(CourseDb courseDb)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserDb userDb)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(CommentDb commentDb)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(CourseDb course)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDb userDb)
        {
            throw new NotImplementedException();
        }
    }
}
