using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class BookmarkConfigurations : EntityTypeConfiguration<CourseBookmarkDb>
    {
        public BookmarkConfigurations()
        {
            ToTable("CourseBookmarks");
            HasKey(x => x.Id);

            HasOptional<UserProfileDb>(x => x.UserProfile);
            HasMany<CourseDb>(x => x.Course);
        }        
    }
}
