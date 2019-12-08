using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.Analytics.DAL.Context.Configurations
{
    internal class ChartConfigurations : EntityTypeConfiguration<ChartDb>
    {
        public ChartConfigurations()
        {
            ToTable("Charts");
            HasKey(_ => _.Id);

            Property(_ => _.Name)
               .IsRequired()
               .HasMaxLength(127)
               .IsUnicode();
        }
    }
}
