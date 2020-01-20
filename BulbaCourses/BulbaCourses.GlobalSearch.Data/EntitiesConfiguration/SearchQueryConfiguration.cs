using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration
{
    class SearchQueryConfiguration : EntityTypeConfiguration<SearchQueryDB>
    {
        public SearchQueryConfiguration()
        {
            ToTable("search_query");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("id");
            Property(i => i.Query).IsRequired()
                .HasColumnName("query_string");
            Property(i => i.Created).HasColumnName("date");
            Property(i => i.UserId).HasColumnName("user_id").IsRequired();
        }
    }
}
