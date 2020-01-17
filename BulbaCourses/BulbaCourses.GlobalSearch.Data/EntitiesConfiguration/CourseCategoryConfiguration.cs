using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class CourseCategoryConfiguration : EntityTypeConfiguration<CourseCategoryDB>
    {
        public CourseCategoryConfiguration()
        {
            ToTable("course_category");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id").HasDatabaseGeneratedOption(null);
            Property(i => i.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);
            Property(i => i.Description).HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
