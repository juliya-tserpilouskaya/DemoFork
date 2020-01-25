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
    public class TaskRepository: IRepository<TaskDb>
    {
        private TasksContext db;
        public TaskRepository(TasksContext context)
        {
            db = context;
        }
        /// <summary>
        /// Get all Tasks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDb>> GetAll()
        {
            return await db.Tasks.ToListAsync();
        }
        /// <summary>
        /// Get Task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaskDb Get(string id)
        {
            return db.Tasks.Find(id);
        }
        /// <summary>
        /// Get tasks async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TaskDb> GetTaskAsync(string id)
        {
            return db.Tasks.FindAsync(id);
        }
        /// <summary>
        /// Add task object in database
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task<TaskDb> Create(TaskDb task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task");
            }
            db.Tasks.Add(task);
            return await Task.FromResult(task);

        }
        /// <summary>
        /// Update Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task<TaskDb> Update(TaskDb task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task");
            }
            db.Entry(task).State = EntityState.Modified;
            return await Task.FromResult(task);
        }
        /// <summary>
        /// Search Task
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TaskDb> Find(Func<TaskDb, Boolean> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }
        /// <summary>
        /// Dekete Task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskDb> Delete(string id)
        {
            TaskDb task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
            return await Task.FromResult(task);
        }
    }
}
