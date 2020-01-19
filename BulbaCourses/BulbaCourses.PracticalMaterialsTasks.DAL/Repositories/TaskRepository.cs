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
        public async Task<IEnumerable<TaskDb>> GetAll()
        {
            return await db.Tasks.ToListAsync();
        }
        public TaskDb Get(string id)
        {
            return db.Tasks.Find(id);
        }
        public Task<TaskDb> GetTaskAsync(string id)
        {
            return db.Tasks.FindAsync(id);
        }
        public async Task<TaskDb> Create(TaskDb task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task");
            }
            db.Tasks.Add(task);
            return await Task.FromResult(task);

        }
        public async Task<TaskDb> Update(TaskDb task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task");
            }
            db.Entry(task).State = EntityState.Modified;
            return await Task.FromResult(task);
        }
        public IEnumerable<TaskDb> Find(Func<TaskDb, Boolean> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }
        public async Task<TaskDb> Delete(string id)
        {
            TaskDb task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
            return await Task.FromResult(task);
        }
    }
}
