using BulbaCourses.PracticalMaterialsTests.Logic.Enum;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Users
{
    public class MUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IEnumerable<EUserRole> UserRoles { get; set; }
    }
}
