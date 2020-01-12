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
        public IEnumerable<TaskDb> GetAll()
        {
            return db.Tasks.ToList();
        }
        public TaskDb Get(string id)
        {
            return db.Tasks.Find(id);
        }
        public void Create(TaskDb task)
        {
            db.Tasks.Add(task);
        }
        public void Update(TaskDb task)
        {
            db.Entry(task).State = EntityState.Modified;
        }
        public IEnumerable<TaskDb> Find(Func<TaskDb, Boolean> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }
        public void Delete(string id)
        {
            TaskDb task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
        }
    }
}
