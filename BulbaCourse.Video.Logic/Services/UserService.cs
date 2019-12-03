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
        public UserDb Add(UserDb user)
        {
            var result = userRepository.Add(user);
            return result;
        }

        public bool AddCourseToUser(string userId, string courseId)
        {
            var result = userRepository.AddCourseToUser(userId, courseId);
            return result;
        }

        public bool AddRole(string newRole)
        {
            var result = userRepository.AddRole(newRole);
            return result;
        }

        public RoleDb CheckRole(RoleDb role)
        {
            var result = userRepository.CheckRole(role);
            return result;
        }

        public void Delete(UserDb user)
        {
            userRepository.Delete(user);
        }

        public void DeleteById(string userId)
        {
            userRepository.DeleteById(userId);
        }

        public bool DeleteCourseFromUser(string userId, string courseId)
        {
            var result = userRepository.DeleteCourseFromUser(userId, courseId);
            return result;
        }

        public IEnumerable<UserDb> GetAll()
        {
            var result = userRepository.GetAll();
            return result;
        }

        public UserDb GetByLogin(string userName)
        {
            var result = userRepository.GetByLogin(userName);
            return result;
        }

        public UserDb GetUserById(string id)
        {
            var result = userRepository.GetUserById(id);
            return result;
        }

        public ICollection<CourseDb> GetUserCourse(string userId)
        {
            var result = userRepository.GetUserCourse(userId);
            return result;
        }
    }
}
