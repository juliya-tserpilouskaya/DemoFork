using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private List<UserDb> _users;

        public FakeUserRepository()
        {
            _users = new List<UserDb>()
            {
                new UserDb()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_2",
                     LastName = "LastName_2"
                },
                new UserDb()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_1",
                     LastName = "LastName_1"
                },
                new UserDb()
                {
                     UserId  = Guid.NewGuid().ToString(),
                     Name = "User_3",
                     LastName = "LastName_3"
                },
            };

        }

        public void Add(UserDb user)
        {
            _users.Add(user);
        }

        public IEnumerable<UserDb> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDb GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserDb user)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDb user)
        {
            throw new NotImplementedException();
        }
    }
}
