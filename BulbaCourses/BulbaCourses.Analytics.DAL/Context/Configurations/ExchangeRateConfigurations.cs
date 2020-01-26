using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.Analytics.DAL.Context.Configurations
{
    internal class ExchangeRateConfigurations : EntityTypeConfiguration<ExchangeRatesDb>
    {
        public ExchangeRateConfigurations()
        {
            ToTable("ExchangeRates");
            HasKey(_ => _.Id);

            Property(_ => _.Date)
               .IsRequired();

            Property(_ => _.KursDollarValue)
                .IsRequired();
        }
    }
}
