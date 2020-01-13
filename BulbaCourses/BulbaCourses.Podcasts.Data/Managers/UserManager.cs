using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Data.Managers
{
    class UserManager : IManager<UserDb>
    {
        public UserDb Add(UserDb userDb)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserDb> GetAll()
        {
            throw new NotImplementedException();
        }
        public UserDb GetById(string id)
        {
            throw new NotImplementedException();
        }
        public UserDb Remove(UserDb userDb)
        {
            throw new NotImplementedException();
        }
        public UserDb Update(UserDb userDb)
        {
            throw new NotImplementedException();
        }
    }
}
