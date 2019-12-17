using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class CourseItemConfiguration : EntityTypeConfiguration<CourseItemDB>
    {
        public CourseItemConfiguration()
        {
            ToTable("course_item");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id");
            Property(i => i.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);
            Property(i => i.Description).HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1000);
            Property(i => i.Url).HasColumnName("url");
        }
    }
}
