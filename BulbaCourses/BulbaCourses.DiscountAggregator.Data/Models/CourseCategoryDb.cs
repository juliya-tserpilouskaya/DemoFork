using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class CourseCategoryDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Title { get; set; }

        //public DomainDb Domain { get; set; }

        public ICollection<SearchCriteriaDb> SearchCriterias { get; set; }
    }
}
