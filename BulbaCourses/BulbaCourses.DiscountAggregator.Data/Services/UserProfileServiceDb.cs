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
    public class UserProfileServiceDb : IUserProfileServiceDb
    {
        private readonly CourseContext context;

        public UserProfileServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public void Add(UserProfileDb profile)
        {
            context.Profiles.Add(profile);
            context.SaveChanges();
        }

        public IEnumerable<UserProfileDb> GetAll()
        {
            var profiles = context.Profiles.ToList().AsReadOnly();
            return profiles;
        }

        public UserProfileDb GetById(string id)
        {
            var profile = context.Profiles.FirstOrDefault(c => c.Id.Equals(id));
            return profile;
        }

        public void Delete(UserProfileDb profile)
        {
            context.Profiles.Remove(profile);
            context.SaveChanges();
        }

        public void Update(UserProfileDb profile)
        {
            if (profile != null)
            {
                context.Entry(profile).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
