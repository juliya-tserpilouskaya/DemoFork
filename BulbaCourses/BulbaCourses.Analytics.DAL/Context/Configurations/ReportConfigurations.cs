using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.Analytics.DAL.Context.Configurations
{
    internal class ReportConfigurations : EntityTypeConfiguration<ReportDb>
    {
        public ReportConfigurations()
        {
            ToTable("Reports");

            HasKey(_ => _.Id);

            HasMany(d => d.Dashboards)
                .WithRequired(d => d.Report)
                .HasForeignKey(k => k.ReportId);

            Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode();

            Property(_ => _.Description)
                .IsOptional()
                .HasMaxLength(255)
                .IsUnicode();

            Property(_ => _.Created)
                .IsOptional();

            Property(_ => _.Modified)
                .IsOptional();

            Property(_ => _.Creator)
                .IsOptional()
                .HasMaxLength(128)
                .IsUnicode();

            Property(_ => _.Modifier)
                .IsOptional()
                .HasMaxLength(128)
                .IsUnicode();
        }
    }
}
