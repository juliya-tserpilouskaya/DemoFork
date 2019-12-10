using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("DbConnection")
        {
        }

        //public DbSet<CourseDb> Courses { get; set; }
        public DbSet<CourseDb> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  //нужно использовать базовый метод, очень полезно и другой вопрос когда его вызывать
        {
            base.OnModelCreating(modelBuilder);

            var entity = modelBuilder.Entity<CourseDb>();

            //using Fluent API
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(255).IsUnicode();
            entity.Property(x => x.Price).IsRequired();

        }
    }
}
