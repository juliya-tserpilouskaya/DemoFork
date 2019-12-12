using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoDbContext videoDbContext;

        public UserRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }

        public void Add(UserDb user)
        {
            videoDbContext.Users.Add(user);
            videoDbContext.SaveChanges();
        }

        public IEnumerable<UserDb> GetAll()
        {
            var userList = videoDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public UserDb GetById(string id)
        {
            var user = videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(id));
            return user;
        }

        public void Remove(UserDb user)
        {
            videoDbContext.Users.Remove(user);
            videoDbContext.SaveChanges();
        }

        public void Update(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            videoDbContext.Entry(user).State = EntityState.Modified;
            videoDbContext.SaveChanges();
        }
    }
}
