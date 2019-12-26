using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class UserAccountServiceDB : IUserAccountDB
    {
        private readonly CourseContext courseContext;

        public UserAccountServiceDB(CourseContext courseService)
        {
            courseContext = courseService;
        }

        public IEnumerable<UserAccountDb> GetAll()
        {
            //var usersList = courseContext.Users.ToList().AsReadOnly();
            var usersList = courseContext.Users./*Include(x => x.UserProfile).*/ToList().AsReadOnly();
            //var usersList2 = courseContext.Users.Include(c => c.Orders()) .Include(c => c.UserPro).ToList().AsReadOnly();
            return usersList;
        }

        public void Add(UserAccountDb userAccount)
        {
            userAccount.Password = HashingPassword.HashPassword(userAccount.Password);
            courseContext.Users.Add(userAccount);
            courseContext.SaveChanges();
        }

    }
}
