using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    class UserProfileConfigurations : EntityTypeConfiguration<UserProfileDb>
    {
        public UserProfileConfigurations()
        {
            ToTable("UserProfiles");
            HasKey(x => x.Id);
            Property(x => x.FirstName).IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode();
            Property(x => x.LastName).IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode();
            Property(x => x.Email).IsRequired()
                .HasMaxLength(105);
            Property(x => x.Subscription).IsRequired();

            //HasOptional<SearchCriteriaDb>(x => x.SearchCriteria).WithMany(p => p.Id).Map(m => m.MapRightKey("Criterias").MapLeftKey("TagId").ToTable("CourseTag"));

            //HasMany<CourseDb>(b => b.Courses).WithMany(t => t.Tags).Map(m => m.MapRightKey("CourseId").MapLeftKey("TagId").ToTable("CourseTag"));

            //HasMany<UserProfileDb>(b => b.Author).WithMany(t => t.Courses).Map(m => m.MapKey("CourseAuthorId"));
        }
    }
}
