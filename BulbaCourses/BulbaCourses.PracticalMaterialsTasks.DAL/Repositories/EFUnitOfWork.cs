using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Context;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private TasksContext db;
        private TaskRepository taskRepository;
        private UserRepository userRepository;
        public EFUnitOfWork(string connectionString)
        {
            db = new TasksContext(connectionString);
        }
        public IRepository<TaskDb> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }
        public IRepository<UserDb> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);

                }
                return userRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
