using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class UserProfileDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public SearchCriteriaDb SearchCriteria { get; set; }

        public bool Subscription { get; set; }

        public DateTime SubscriptionDateStart { get; set; }

        public DateTime SubscriptionDateEnd { get; set; }        
    }
}
