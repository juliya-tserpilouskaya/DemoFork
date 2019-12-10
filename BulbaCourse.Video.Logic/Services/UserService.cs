using BulbaCourse.Video.Data.Interfaces;
using BulbaCourse.Video.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Add(UserDb user)
        {
            userRepository.Add(user);
        }

        public void AddCourseToUser(string userId, CourseDb course)
        {
            var userCourses = userRepository.GetById(userId).Courses;
            userCourses.Add(course);
        }

        public void AddRoleToUser(string userId, RoleDb role)
        {
            var userRoles = userRepository.GetById(userId).Roles;
            userRoles.Add(role);
        }

        public void Delete(UserDb user)
        {
            userRepository.Remove(user);
        }

        public void DeleteById(string userId)
        {
            var user = userRepository.GetById(userId);
            userRepository.Remove(user);
        }

        public void DeleteCourseFromUser(string userId, string courseId)
        {
            var courses = userRepository.GetById(userId).Courses;
            var courseToDel = courses.FirstOrDefault(c => c.CourseId.Equals(courseId));
            courses.Remove(courseToDel);
        }

        public IEnumerable<UserDb> GetAll()
        {
            var result = userRepository.GetAll();
            return result;
        }

        public UserDb GetByLogin(string userName)
        {
            var user = userRepository.GetAll().FirstOrDefault(c => c.Login.Equals(userName));
            return user;
        }

        public UserDb GetUserById(string id)
        {
            var result = userRepository.GetById(id);
            return result;
        }

        public IEnumerable<CourseDb> GetUserCourse(string userId)
        {
            var user = userRepository.GetById(userId);
            var couses = user.Courses.ToList().AsReadOnly();
            return couses;
        }
    }
}
