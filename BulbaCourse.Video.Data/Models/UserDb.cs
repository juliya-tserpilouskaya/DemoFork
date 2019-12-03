using BulbaCourse.Video.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class UserDb
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AvatarPath { get; set; }
        public Subscription SubscriptionType { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }

        public ICollection<RoleDb> Roles { get; set; }
        public ICollection<TransactionDb> Transactions { get; set; }
        public ICollection<CourseDb> Courses { get; set; }
        public ICollection<CommentDb> Comments { get; set; }
    }
}
