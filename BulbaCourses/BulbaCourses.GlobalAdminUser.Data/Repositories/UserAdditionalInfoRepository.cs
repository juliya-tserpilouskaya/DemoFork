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
    public class UserAdditionalInfoRepository : IUserAdditonalInfoRepository
    {
        private readonly GlobalAdminDbContext dbContext;
        public UserAdditionalInfoRepository(GlobalAdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<UserAdditionalInfoDb> GetByIdAsync(string id)
        {
            var chosenUser = dbContext.UsersAdditionalInfo.SingleOrDefault(x => x.UserId.Equals(id));            
            return Task.FromResult(chosenUser);
        }

        public void Remove(UserAdditionalInfoDb user)
        {
            throw new NotImplementedException();
        }

        public void Update(UserAdditionalInfoDb user)
        {
            throw new NotImplementedException();
        }
    }
}
