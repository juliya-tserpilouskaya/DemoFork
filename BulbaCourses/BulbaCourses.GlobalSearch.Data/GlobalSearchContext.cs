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
        public GlobalSearchContext() : base()
        {
            Database.Log = s => Debug.WriteLine(s);
            //Database.SetInitializer(new GlobalSearchDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new CourseItemConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseCategoryConfiguration());
            modelBuilder.Configurations.Add(new SearchQueryConfiguration());
            modelBuilder.Configurations.Add(new BookmarkConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public virtual DbSet<AuthorDB> Authors { get; set; }
        public virtual DbSet<SearchQueryDB> SearchQueries { get; set; }
        public virtual DbSet<CourseCategoryDB> Categories { get; set; }
        public virtual DbSet<CourseDB> Courses { get; set; }
        public virtual DbSet<CourseItemDB> CourseItems { get; set; }
        public virtual DbSet<BookmarkDB> Bookmarks { get; set; }
        public virtual DbSet<UserDB> Users { get; set; }
    }
}
