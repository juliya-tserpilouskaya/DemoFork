using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Models
{
    public class UserProfileDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
