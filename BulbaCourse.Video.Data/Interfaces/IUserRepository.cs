using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetByLogin(string userName);
        User GetUserById(string id);
        IEnumerable<User> GetAll();
        User Add(User user);
        void Delete(User user);
        void DeleteById(string userId);
        ICollection<Course> GetUserCourse(string userId);
        Role CheckRole(Role role);
        bool AddRole(string newRole);
        bool AddCourseToUser(string userId, string courseId);
        bool DeleteCourseFromUser(string userId, string courseId);
    }
}
