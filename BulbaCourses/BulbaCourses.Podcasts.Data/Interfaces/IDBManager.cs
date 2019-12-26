using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Data.Interfaces
{
    public interface IDBManager
    {
        #region Comments
        CommentDb GetCommentById(string id);
        IEnumerable<CommentDb> GetAllComments();
        void AddComment(CommentDb commentDb);
        void RemoveComment(CommentDb commentDb);
        void UpdateComment(CommentDb commentDb);
        #endregion
        #region Users
        void AddUser(UserDb userDb);
        void RemoveUser(UserDb userDb);
        IEnumerable<UserDb> GetAllUsers();
        UserDb GetUserById(string id);
        void UpdateUser(UserDb userDb);
        #endregion
        #region Courses
        void AddCourse(CourseDb courseDb);
        CourseDb GetCourseById(string id);
        void UpdateCourse(CourseDb course);
        IEnumerable<CourseDb> GetAllCourses();
        void RemoveCourse(CourseDb courseDb); 
        #endregion

    }
}
