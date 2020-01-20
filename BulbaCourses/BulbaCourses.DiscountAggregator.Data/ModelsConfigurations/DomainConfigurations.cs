using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.DiscountAggregator.Data.ModelsConfigurations
{
    public class DomainConfigurations : EntityTypeConfiguration<DomainDb>
    {
        public DomainConfigurations()
        {
            ToTable("Domains");
            HasKey(x => x.Id);
            //HasKey(x => x.DomainName);
            //HasKey(x => x.DomainURL);
            Property(x => x.DomainName).IsRequired()
                .HasMaxLength(255)
                .IsUnicode();
            Property(x => x.DomainURL).IsRequired()
                .HasMaxLength(500)
                .IsUnicode();
        }
    }
}
