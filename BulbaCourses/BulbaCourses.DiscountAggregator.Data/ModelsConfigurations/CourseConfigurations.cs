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
            Property(x => x.URL).IsRequired()
                .HasMaxLength(500)
                .IsUnicode();
            Property(x => x.Title).IsRequired()
                .HasMaxLength(255)
                .IsUnicode();
            Property(x => x.Description)
                .HasMaxLength(5000)
                .IsUnicode();
            Property(x => x.Price).IsRequired();
            
            HasOptional<DomainDb>(x => x.Domain);
            HasOptional<CourseCategoryDb>(x => x.Category);
        }
    }
}
