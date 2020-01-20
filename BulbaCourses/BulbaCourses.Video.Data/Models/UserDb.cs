using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class UserDb
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string Login { get; set; }
        //public string AvatarPath { get; set; }
        //public DateTime? Birthdate { get; set; }
        //public string Gender { get; set; }
        //public string Religion { get; set; }

        public int SubscriptionType { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }

        public ICollection<TransactionDb> Transactions { get; set; }
        public ICollection<CourseDb> Courses { get; set; }
        public ICollection<CommentDb> Comments { get; set; }
    }
}
