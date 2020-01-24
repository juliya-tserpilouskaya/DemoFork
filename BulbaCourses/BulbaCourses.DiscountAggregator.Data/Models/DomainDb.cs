using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class DomainDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string DomainName { get; set; }

        public string DomainURL { get; set; }

        public ICollection<SearchCriteriaDb> SearchCriterias { get; set; }

        //public ICollection<CourseDb> Courses { get; set; }
    }
}
