using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class PresentationsContext : DbContext
    {
        public PresentationsContext() : base("PresentationsConnection")
        {
            Database.Log = s => Debug.WriteLine(s);
            Database.SetInitializer<PresentationsContext>(new PresentationsContextInitializer());
        }

        public PresentationsContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<PresentationsContext>(new FakeContextInitializer());
        }

        public virtual DbSet<CourseDB> Courses { get; set; }

        public virtual DbSet<FeedbackDB> Feedbacks { get; set; }

        public virtual DbSet<PresentationDB> Presentations { get; set; }

        public virtual DbSet<StudentDB> Students { get; set; }

        public virtual DbSet<TeacherDB> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseDBConfiguration());

            modelBuilder.Configurations.Add(new FeedbackDBConfiguration());

            modelBuilder.Configurations.Add(new PresentationDBConfiguration());

            modelBuilder.Configurations.Add(new TeacherConfiguration());

            modelBuilder.Configurations.Add(new StudentConfiguration());
        }
    }
}
