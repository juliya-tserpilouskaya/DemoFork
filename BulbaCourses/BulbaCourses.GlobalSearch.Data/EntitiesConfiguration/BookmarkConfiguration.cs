using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class BookmarkConfiguration : EntityTypeConfiguration<BookmarkDB>
    {
        public BookmarkConfiguration()
        {
            ToTable("bookmark");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id");
            Property(i => i.UserId).HasColumnName("user_id").IsRequired();
            Property(i => i.Title).HasColumnName("title").HasMaxLength(255);
            Property(i => i.URL).HasColumnName("url").IsRequired().HasMaxLength(255);
        }
    }
}
