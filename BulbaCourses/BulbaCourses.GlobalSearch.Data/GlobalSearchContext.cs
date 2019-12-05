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

        }


        public virtual DbSet<AuthorDB> Authors { get; set; }
        public virtual DbSet<SearchQueryDB> SearchQueries { get; set; }
        public virtual DbSet<ExcerciseCourseDB> ExcerciseCourses { get; set; }
        public virtual DbSet<ExcerciseDB> Excercises { get; set; }
        public virtual DbSet<PodcastDB> Podcasts { get; set; }
        public virtual DbSet<PodcastCourseDB> PodcastCourses { get; set; }
        public virtual DbSet<TestCourseDB> TestCourses { get; set; }
        public virtual DbSet<TestDB> Tests { get; set; }
        public virtual DbSet<ArticleCourseDB> TextCourses { get; set; }
        public virtual DbSet<ArticleDB> Texts { get; set; }
        public virtual DbSet<VideoCourseDB> VideoCourses { get; set; }
        public virtual DbSet<VideoDB> Videos { get; set; }
    }
}
