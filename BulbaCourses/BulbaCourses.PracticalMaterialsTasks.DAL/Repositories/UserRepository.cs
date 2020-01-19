using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using BulbaCourses.PracticalMaterialsTasks.DAL.Context;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Repositories
{
    public class UserRepository: IRepository<UserDb>
    {
        private TasksContext db;

        public UserRepository(TasksContext context)
        {
            this.db = context;
        }

        public Task<IEnumerable<UserDb>> GetAll()
        {
            return Task.FromResult(db.Users.AsEnumerable());
        }

        public UserDb Get(string id)
        {
            return db.Users.Find(id);
        }
        public Task<UserDb> GetTaskAsync(string id)
        {
            return db.Users.FindAsync(id);
        }
        public async Task<UserDb> Create(UserDb user)
        {
            db.Users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<UserDb> Update(UserDb user)
        {
            db.Entry(user).State = EntityState.Modified;
            return await Task.FromResult(user);
        }

        public IEnumerable<UserDb> Find(Func<UserDb,Boolean> predicate)
        {
            return db.Users.Include(u => u.NickName).Where(predicate).ToList();
        }

        public Task<UserDb> Delete(string id)
        {
            UserDb user = db.Users.Find(id);
            if(user != null)
            {
                db.Users.Remove(user);
            }
            return Task.FromResult(user);
        }
    }
}
