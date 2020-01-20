using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Models
{
    public class UserInfo
    {
        public string Login { get; set; }
        public string AvatarPath { get; set; }
        public int SubscriptionType { get; set; }
        public bool IsSubscriptionConfirmed { get; set; }
    }
}
