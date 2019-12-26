using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Property(x => x.Subscription).IsRequired();
        }
    }
}
