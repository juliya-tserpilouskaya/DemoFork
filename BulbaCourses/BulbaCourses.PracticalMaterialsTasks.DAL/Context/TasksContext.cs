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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDb>().ToTable("Tasks").HasKey(t => t.Id);
            modelBuilder.Entity<TaskDb>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TaskDb>().Property(t => t.TaskLevel).IsRequired();
            modelBuilder.Entity<TaskDb>().Property(t => t.Text).IsRequired();

            modelBuilder.Entity<UserDb>().ToTable("Users").HasKey(t => t.Id);
            modelBuilder.Entity<UserDb>().Property(t => t.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<UserDb>().Property(t => t.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<UserDb>().Property(t => t.NickName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<UserDb>().Property(t => t.Password).IsRequired().HasMaxLength(20);
            
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
