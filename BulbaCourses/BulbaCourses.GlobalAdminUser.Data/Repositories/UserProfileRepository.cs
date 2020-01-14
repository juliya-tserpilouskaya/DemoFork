using BulbaCourses.GlobalAdminUser.Data.Context;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Repositories
{
    public class UserProfileRepository : IRepository<UserProfileDb>
    {
        private readonly GlobalAdminDbContext dbContext;
        public UserProfileRepository(GlobalAdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(UserProfileDb user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfileDb> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserProfileDb GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserProfileDb user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfileDb user)
        {
            throw new NotImplementedException();
        }
    }
}
