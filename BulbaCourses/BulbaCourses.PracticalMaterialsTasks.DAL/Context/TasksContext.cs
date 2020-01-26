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
        
        public  DbSet<UserDb> Users { get; set; }
        public DbSet<TaskDb> Tasks { get; set; }

        public TasksContext() { }
        static TasksContext()
        {
            Database.SetInitializer<TasksContext>(new DbInitializer());
        }
        public TasksContext(string connectionString) : base(connectionString)
        {
           
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskDb>().ToTable("Tasks").HasKey(t => t.Id);
            modelBuilder.Entity<TaskDb>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TaskDb>().Property(t => t.TaskLevel).IsRequired();
            modelBuilder.Entity<TaskDb>().Property(t => t.Text).IsRequired();
            modelBuilder.Entity<TaskDb>().Property(t => t.Created).IsRequired();


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
            context.Tasks.Add(new TaskDb() { Name = "Задача 1", TaskLevel = "1", Text = "Найти квадратный корень числа Х", Created = DateTime.Now });
            context.Tasks.Add(new TaskDb() { Name = "Задача 2", TaskLevel = "1", Text = "Найти квадратный корень числа Y", Created = DateTime.Now });
            context.Users.Add(new UserDb() { FirstName = "Ivan", LastName = "Ivanov", NickName = "Ivan", Email = "Ivanov@mail.ru", Password = "1234567" });
            context.SaveChanges();
             base.Seed(context);
        }
    }
}
