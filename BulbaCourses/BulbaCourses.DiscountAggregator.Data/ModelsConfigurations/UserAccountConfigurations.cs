using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class UserAccountConfigurations : EntityTypeConfiguration<UserAccountDb>
    {
        public UserAccountConfigurations()
        {
            ToTable("UserAccounts");
            HasKey(x => x.Id);
            Property(x => x.Login).IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode();
            Property(x => x.Password).IsRequired().HasMaxLength(300);
            Property(x => x.Email).IsRequired().HasMaxLength(105);

            HasOptional<UserProfileDb>(x => x.UserProfile);
        }
    }
}
