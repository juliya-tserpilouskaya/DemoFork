using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.Analytics.DAL.Context.Configurations
{
    internal class DashboardConfigurations : EntityTypeConfiguration<DashboardDb>
    {
        public DashboardConfigurations()
        {
            ToTable("Dashboards");

            HasKey(_ => _.Id);

            Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode();

            Property(_ => _.ReportId)
                .IsRequired();

            Property(_ => _.Created)
                .IsOptional();

            Property(_ => _.Modified)
                .IsOptional();

            Property(_ => _.Creator)
                .IsOptional()
                .HasMaxLength(255)
                .IsUnicode();

            Property(_ => _.Modifier)
                .IsOptional()
                .HasMaxLength(255)
                .IsUnicode();
        }
    }
}
