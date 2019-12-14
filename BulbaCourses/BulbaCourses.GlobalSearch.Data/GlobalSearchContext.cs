using BulbaCourses.GlobalSearch.Data.EntitiesConfiguration;
using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data
{
    public class GlobalSearchContext : DbContext
    {
        public GlobalSearchContext() : base("GlobalSearchContext")
        {
            Database.Log = s => Debug.WriteLine(s);
            Database.SetInitializer(new GlobalSearchDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new CourseItemConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseCategoryConfiguration());
        }

        public DbSet<AuthorDB> Authors { get; set; }
        public DbSet<SearchQueryDB> SearchQueries { get; set; }
        public DbSet<CourseCategoryDB> Categories { get; set; }
        public DbSet<CourseDB> Courses { get; set; }
        public DbSet<CourseItemDB> CourseItems { get; set; }
    }
}
