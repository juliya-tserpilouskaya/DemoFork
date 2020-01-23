using BulbaCourses.GlobalAdminUser.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Models
{
    public class UserDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string UserRoles { get; set; }

        public bool LockoutEnabled { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
