using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string URL { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }
        public int OldDiscount { get; set; }

        public string Description { get; set; }
    }
}
