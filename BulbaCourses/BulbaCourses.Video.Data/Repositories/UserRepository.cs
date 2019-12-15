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
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(UserDb user)
        {
            _videoDbContext.Users.Add(user);
            _videoDbContext.SaveChanges();
        }

        public IEnumerable<UserDb> GetAll()
        {
            var userList = _videoDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public UserDb GetById(string id)
        {
            var user = _videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(id));
            return user;
        }

        public void Remove(UserDb user)
        {
            _videoDbContext.Users.Remove(user);
            _videoDbContext.SaveChanges();
        }

        public void Update(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Entry(user).State = EntityState.Modified;
            _videoDbContext.SaveChanges();
        }
    }
}
