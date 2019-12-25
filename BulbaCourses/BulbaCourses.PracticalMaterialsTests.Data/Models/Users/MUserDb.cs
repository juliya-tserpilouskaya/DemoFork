using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Users
{
    public class MUserDb
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> UserRoles { get; set; }
    }
}
