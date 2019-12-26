using BulbaCourses.DiscountAggregator.Data.Migrations;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.ModelsConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("DADbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CourseContext, Configuration>());
        }

        public DbSet<CourseDb> Courses { get; set; }
        public DbSet<UserAccountDb> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  //нужно использовать базовый метод, очень полезно и другой вопрос когда его вызывать
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CourseConfigurations());
        }

        
    }
}
