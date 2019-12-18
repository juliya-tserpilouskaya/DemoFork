using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class UserAccount
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public UserProfile UserProfile { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
