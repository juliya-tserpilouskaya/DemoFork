using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Models
{
    public class UserProfileDTO
    {
        public UserDTO User { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }

        public string ProfilePictureUrl { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
