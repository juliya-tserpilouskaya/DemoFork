using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.InterfaceServices
{
    public interface IUserService
    {
        UserDb GetByLogin(string userName);
        UserDb GetUserById(string id);
        IEnumerable<UserDb> GetAll();
        void Add(UserDb user);
        void Delete(UserDb user);
        void DeleteById(string userId);
        IEnumerable<CourseDb> GetUserCourse(string userId);
        RoleDb CheckRole(RoleDb role);
        bool AddRole(string newRole);
        bool AddCourseToUser(string userId, string courseId);
        bool DeleteCourseFromUser(string userId, string courseId);
    }
}
