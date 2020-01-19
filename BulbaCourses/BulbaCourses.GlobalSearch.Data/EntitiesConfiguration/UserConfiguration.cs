using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class UserConfiguration : EntityTypeConfiguration<UserDB>
    {
        public UserConfiguration()
        {
            ToTable("user");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("id");
            Property(u => u.Authorization).HasColumnName("authorization").IsRequired();
        }
    }
}
