using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BulbaCourses.GlobalSearch.Data.Models;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class AuthorConfiguration : EntityTypeConfiguration<AuthorDB>
    {
        public AuthorConfiguration()
        {
            ToTable("author");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id");
            Property(i => i.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
