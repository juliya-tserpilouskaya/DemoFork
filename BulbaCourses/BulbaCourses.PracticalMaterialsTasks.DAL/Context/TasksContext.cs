using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }
        public DbSet<Models.TaskDb> Tasks { get; set; }

        static TasksContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }
        public TasksContext(string connectionString) : base(connectionString)
        { }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TasksContext>
    {
        protected override void Seed(TasksContext context)
        {
            base.Seed(context);
        }
    }
}
