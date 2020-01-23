using System;
using System.Linq;

namespace BulbaCourses.GlobalAdminUser.Logic.Models
{
    public class UserDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserRoles { get; set; }

        public string Lockout { get; set; }


        //public string TelephoneNumber { get; set; }

    }
}
