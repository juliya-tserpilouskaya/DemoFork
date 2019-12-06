using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoDbContext videoDbContext;

        public UserRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }
        public void Add(UserDb user)
        {
            videoDbContext.Users.Add(user);
            videoDbContext.SaveChanges();
        }

        public bool AddCourseToUser(string userId, string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            if (course != null)
            {
                var user = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(userId));
                user.Courses.Add(course);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddRole(string newRole)
        {
            var role = videoDbContext.Roles.FirstOrDefault(b => b.RoleName.Equals(newRole));
            if (role == null)
            {
                role = new RoleDb { RoleName = newRole };
                videoDbContext.Roles.Add(role);
                videoDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public RoleDb CheckRole(RoleDb role)
        {
            var result = videoDbContext.Roles.FirstOrDefault(b => b.RoleName.Equals(role.RoleName));
            if (result == null)
            {
                videoDbContext.Roles.Add(role);
                videoDbContext.SaveChanges();
                result = role;
            }
            return result;
        }

        public void Remove(UserDb user)
        {
            videoDbContext.Users.Remove(user);
            videoDbContext.SaveChanges();
        }

        public void RemoveById(string userId)
        {
            var deletedUser = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(userId));
            videoDbContext.Users.Remove(deletedUser);
            videoDbContext.SaveChanges();
        }

        public bool DeleteCourseFromUser(string userId, string courseId)
        {
            var user = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(userId));
            var deletedCourse = user.Courses.FirstOrDefault(p => p.CourseId.Equals(courseId));
            if (deletedCourse != null)
            {
                user.Courses.Remove(deletedCourse);
                videoDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<UserDb> GetAll()
        {
            var userList = videoDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public UserDb GetByLogin(string userName)
        {
            var user = videoDbContext.Users.FirstOrDefault(b => b.Login.Equals(userName));
            return user;
        }

        public UserDb GetById(string id)
        {
            var user = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(id));
            return user;
        }

        public IEnumerable<CourseDb> GetUserCourse(string userId)
        {
            var user = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(userId));
            var courses = user.Courses;
            return courses;
        }

        public void Update(UserDb user)
        {
            videoDbContext.Entry(user).State = EntityState.Modified;
            videoDbContext.SaveChanges();
        }
    }
}
