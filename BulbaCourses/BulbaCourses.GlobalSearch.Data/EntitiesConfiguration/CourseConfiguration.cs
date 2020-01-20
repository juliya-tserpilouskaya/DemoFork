using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class CourseConfiguration : EntityTypeConfiguration<CourseDB>
    {
        public CourseConfiguration()
        {
            ToTable("course");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id");
            Property(i => i.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);
            Property(i => i.Description).HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1000);
            Property(i => i.Created).HasColumnName("created");
            Property(i => i.Cost).HasColumnName("cost");
            Property(i => i.Complexity).HasColumnName("complexity");
            Property(i => i.Language).HasColumnName("language");
            Property(i => i.Modified).HasColumnName("modified");
            Property(i => i.CourseCategoryDBId).HasColumnName("course_category_id");
        }
    }
}
