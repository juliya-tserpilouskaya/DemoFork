using BulbaCourses.GlobalAdminUser.Data.Context;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private GlobalAdminDbContext _globalAdminDbContext;

        public UserRepository(GlobalAdminDbContext globalAdminDbContext)
        {
            _globalAdminDbContext = globalAdminDbContext;
        }

        public void Add(UserDb user)
        {
            _globalAdminDbContext.Users.Add(user);
            _globalAdminDbContext.SaveChanges();
        }

        public IEnumerable<UserDb> GetAll()
        {
            var userList = _globalAdminDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public UserDb GetById(string id)
        {
            var chosenuser = _globalAdminDbContext.Users.SingleOrDefault(x => x.Id.Equals(id));
            return chosenuser;
        }

        public void Remove(UserDb user)
        {
            _globalAdminDbContext.Users.Remove(user);
            _globalAdminDbContext.SaveChanges();
        }

        public void Update(UserDb user)
        {
            _globalAdminDbContext.Entry(user).State = EntityState.Modified;
            _globalAdminDbContext.SaveChanges();
        }
    }
}
