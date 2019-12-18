using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class CourseConfigurations : EntityTypeConfiguration<CourseDb>
    {
        public CourseConfigurations()
        {
            ToTable("Courses");
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired()
                .HasMaxLength(255)
                .IsUnicode();
            Property(x => x.Price).IsRequired();
        }
    }
}
