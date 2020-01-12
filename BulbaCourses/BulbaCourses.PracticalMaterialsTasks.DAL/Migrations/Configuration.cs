using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Migrations

{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.PracticalMaterialsTasks.DAL.Context.TasksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BulbaCourses.PracticalMaterialsTasks.DAL.Context.TasksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Tasks.Add(new TaskDb() { Name = "Задача 1", TaskLevel = "1", Text = "Найти квадратный корень числа Х", Created = DateTime.Now });
            context.Tasks.Add(new TaskDb() { Name = "Задача 2", TaskLevel = "1", Text = "Найти квадратный корень числа Y", Created = DateTime.Now });
            context.Users.Add(new UserDb() { FirstName = "Ivan", LastName = "Ivanov", NickName = "Ivan", Email = "Ivanov@mail.ru", Password = "1234567" });
            context.SaveChanges();
            base.Seed(context);

        }
    }
}
