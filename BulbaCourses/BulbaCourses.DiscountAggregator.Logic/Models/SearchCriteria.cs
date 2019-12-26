using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class SearchCriteria
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public IEnumerable<string> Domains { get; set; }

        public IEnumerable<CourseCategory> CourseCategories { get; set; }

        public double MinPrice {
            set { if (value >= 0) MinPrice = value; }
            get { return MinPrice; }
        }

        public double MaxPrice {
            set { if (value >= 0) MaxPrice = value; }
            get { return MaxPrice; }
        }

        public int MinDiscount {
            set { if (value >= 0 && value <= 100) MinDiscount = value;}
            get { return MinDiscount; }
        }

        public int MaxDiscount {
            set { if (value >= 0 && value <= 100) MaxDiscount = value; }
            get { return MaxDiscount; }
        }
    }
}
