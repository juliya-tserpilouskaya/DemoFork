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

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>Tasks object</returns>
        public Task<IEnumerable<UserDb>> GetAll()
        {
            return Task.FromResult(db.Users.AsEnumerable());
        }
        /// <summary>
        /// Get one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDb Get(string id)
        {
            return db.Users.Find(id);
        }
        /// <summary>
        /// Get one user by async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<UserDb> GetTaskAsync(string id)
        {
            return db.Users.FindAsync(id);
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDb> Create(UserDb user)
        {
            db.Users.Add(user);
            return await Task.FromResult(user);
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDb> Update(UserDb user)
        {
            db.Entry(user).State = EntityState.Modified;
            return await Task.FromResult(user);
        }
        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<UserDb> Find(Func<UserDb,Boolean> predicate)
        {
            return db.Users.Include(u => u.NickName).Where(predicate).ToList();
        }
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
