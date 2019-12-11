using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class UserProfile
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
            
        public IEnumerable<SearchCriteria> SearchCriterias { get; set; }

        public bool Subscription { get; set; }
        public DateTime? SubscriptionDateStart { get; set; }
        public DateTime? SubscriptionDateEnd { get; set; }


    }
}
