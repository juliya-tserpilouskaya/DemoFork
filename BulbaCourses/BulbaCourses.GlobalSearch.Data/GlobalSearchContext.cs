using BulbaCourses.GlobalSearch.Data.EntitiesConfiguration;
using BulbaCourses.GlobalSearch.Data.EntitiesConfiguration.CoursesConfiguration;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data
{
    class GlobalSearchContext : DbContext
    {
        public GlobalSearchContext() : base("GlobalSearchDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
        }


        public virtual DbSet<AuthorDB> Authors { get; set; }
        public virtual DbSet<SearchQueryDB> SearchQueries { get; set; }
    }
}
