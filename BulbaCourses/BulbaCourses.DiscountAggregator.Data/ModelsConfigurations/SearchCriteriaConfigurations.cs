using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class SearchCriteriaConfigurations : EntityTypeConfiguration<SearchCriteriaDb>
    {
        public SearchCriteriaConfigurations()
        {
            ToTable("SearchCriterias");
            HasKey(x => x.Id);
            Property(x => x.MaxDiscount).IsRequired();
            Property(x => x.MaxPrice).IsRequired();
            Property(x => x.MinDiscount).IsRequired();
            Property(x => x.MinPrice).IsRequired();

            HasMany<DomainDb>(x => x.Domains);
            HasMany<CourseCategoryDb>(x => x.CourseCategories);
        }
    }
}
