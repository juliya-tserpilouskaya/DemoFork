using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class CategoryConfigurations : EntityTypeConfiguration<CourseCategoryDb>
    {
        public CategoryConfigurations()
        {
            ToTable("CourseCategories");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired()
                .HasMaxLength(255)
                .IsUnicode();
            Property(x => x.Title).IsRequired()
                .HasMaxLength(255)
                .IsUnicode();
            HasMany(x => x.SearchCriterias)
                .WithMany(p => p.CourseCategories)
                .Map(m =>
                {
                    m.ToTable("SearchCriteriaDbCourseCategoryDbs");

                    m.MapLeftKey("SearchCriteriaDb_Id");
                    m.MapRightKey("CourseCategoryDb_Id");
                }
                );
            //HasOptional<DomainDb>(x => x.Domain);
        }
    }
}
