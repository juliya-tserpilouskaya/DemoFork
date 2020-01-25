using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class CourseDBConfiguration : EntityTypeConfiguration<CourseDB>
    {
        public CourseDBConfiguration()
        {
            ToTable("Courses");

            HasKey(_ => _.Id);

            Property(_ => _.Name).IsRequired().HasMaxLength(255).IsUnicode();
            HasIndex(_ => _.Name).IsUnique(true);

            Property(_ => _.Update).IsRequired();

            HasMany<PresentationDB>(_ => _.CoursePresentations).WithOptional(_ => _.CourseDB).HasForeignKey(_ => _.CourseDBId);
        }
    }
}
