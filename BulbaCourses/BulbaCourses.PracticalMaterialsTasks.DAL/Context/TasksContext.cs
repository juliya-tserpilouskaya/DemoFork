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
        const string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\TaskDB.mdf';Integrated Security=True";
        public DbSet<UserDb> Users { get; set; }
        public DbSet<TaskDb> Tasks { get; set; }

        static TasksContext()
        {
            Database.SetInitializer<TasksContext>(new DbInitializer());
        }
        public TasksContext(string connectionString) : base(connectionString)
        {
            connectionString = _connectionString;
        }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<TasksContext>
    {
        protected override void Seed(TasksContext context)
        {
            context.Tasks.Add(new TaskDb() { Name = "Задача 1", TaskLevel = "1", Text = "Найти квадратный корень числа Х" });
            context.Tasks.Add(new TaskDb() { Name = "Задача 2", TaskLevel = "1", Text = "Найти квадратный корень числа Y" });
            context.Users.Add(new UserDb() { FirstName = "Ivan", LastName = "Ivanov", NickName = "Ivan", Email = "Ivanov@mail.ru", Password = "1234567" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
