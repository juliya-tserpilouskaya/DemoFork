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
            var usersList = courseContext.Users/*.Include(x => x.UserProfile)*/.ToList().AsReadOnly();
            return usersList;
        }

        public void Add(UserAccountDb userAccount)
        {
            userAccount.Password = HashingPassword.HashPassword(userAccount.Password);
            courseContext.Users.Add(userAccount);
            courseContext.SaveChanges();
        }

        public void Update(UserAccountDb userAccount)
        {
            if (userAccount != null)
            {
                courseContext.Entry(userAccount).State = EntityState.Modified;
                courseContext.SaveChanges();
            }
        }

    }
}
