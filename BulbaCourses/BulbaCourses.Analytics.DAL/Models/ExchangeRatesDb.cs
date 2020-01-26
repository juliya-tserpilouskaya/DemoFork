using System;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class ExchangeRatesDb
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double  KursDollarValue { get; set; }
    }
}
