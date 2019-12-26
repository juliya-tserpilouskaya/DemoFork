using BulbaCourses.DiscountAggregator.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class UserAccountDb 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public UserProfileDb IdUserProfile { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
