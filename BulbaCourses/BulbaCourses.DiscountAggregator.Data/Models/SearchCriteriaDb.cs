using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class SearchCriteriaDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public ICollection<DomainDb> Domains { get; set; }

        public ICollection<CourseCategoryDb> CourseCategories { get; set; }

        public double MinPrice { get; set; }
        //set { if (value >= 0) MinPrice = value; }
        //get { return MinPrice; }
        //}

        public double MaxPrice { get; set; }
        //set { if (value >= -0.99)
        //        MaxPrice = value; }
        //get { return MaxPrice; }
        //}

        public int MinDiscount { get; set; }
        //    set { if (value >= 0 && value <= 100) MinDiscount = value;}
        //    get { return MinDiscount; }
        //}

        public int MaxDiscount { get; set; }
    }
}
