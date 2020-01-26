using System;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class ExchangeRatesDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double  KursDollarValue { get; set; }

        public double Value { get; set; }
    }
}
