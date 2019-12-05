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
        UserDb GetByLogin(string userName);
        UserDb GetById(string id);
        IEnumerable<UserDb> GetAll();
        void Add(UserDb user);
        void Update(UserDb user);
        void Remove(UserDb user);
        void RemoveById(string userId);
        ICollection<CourseDb> GetUserCourse(string userId);
        RoleDb CheckRole(RoleDb role);
        bool AddRole(string newRole);
        bool AddCourseToUser(string userId, string courseId);
        bool DeleteCourseFromUser(string userId, string courseId);
    }
}
