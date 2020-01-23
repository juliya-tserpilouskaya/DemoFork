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
        private IUsersContext _usersContext;
        private GlobalAdminDbContext _globalAdminDbContext;

        public UserRepository(GlobalAdminDbContext globalAdminDbContext,UsersContext usersContext)
        {
            _globalAdminDbContext = globalAdminDbContext;
            _usersContext = usersContext;
        }

        public void Add(UserDb user)
        {
            throw new NotImplementedException();
            //_globalAdminDbContext.Users.Add(user);
            //_globalAdminDbContext.SaveChanges();
        }

        public async Task ChangePassword(UserChangePassword user)
        {
            await _usersContext.ChangePassword(user);
        }

        public async Task<IEnumerable<UserDb>> GetAllAsync()
        {
            var userList = await _usersContext.GetAll();            
            //var userList = _globalAdminDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public UserDb GetById(string id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public async Task<UserDb> GetByIdAsync(string id)
        {
            var user = await _usersContext.GetById(id);
            return user;
            throw new NotImplementedException();
            //var chosenuser = _globalAdminDbContext.Users.SingleOrDefault(x => x.Id.Equals(id));
            //return chosenuser;
        }

        public void Remove(UserDb user)
        {
            throw new NotImplementedException();
            //_globalAdminDbContext.Users.Remove(user);
            //_globalAdminDbContext.SaveChanges();
        }

        public void Update(UserDb user)
        {
            _globalAdminDbContext.Entry(user).State = EntityState.Modified;
            _globalAdminDbContext.SaveChanges();
        }
        public async Task<IEnumerable<RoleDb>> GetRolesAsync()
        {
            return await _usersContext.GetRolesAsync();
        }

    }
}
