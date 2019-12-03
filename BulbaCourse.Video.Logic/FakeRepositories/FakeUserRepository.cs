using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private List<User> _users;

        public FakeUserRepository()
        { 
            _users = new List<User>() 
            {
                new User()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_2",
                     LastName = "LastName_2"
                },
                new User()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_1",
                     LastName = "LastName_1"
                },
                new User()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_3",
                     LastName = "LastName_3"
                },
            };

        }
        public User Add(User user)
        {
            _users.Add(user);
            return user;
        }

        public bool AddCourseToUser(string userId, string courseId)
        {
            throw new NotImplementedException();
        }

        public bool AddRole(string newRole)
        {
            throw new NotImplementedException();
        }

        public Role CheckRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCourseFromUser(string userId, string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList().AsReadOnly();
        }

        public User GetByLogin(string userName)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Course> GetUserCourse(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
