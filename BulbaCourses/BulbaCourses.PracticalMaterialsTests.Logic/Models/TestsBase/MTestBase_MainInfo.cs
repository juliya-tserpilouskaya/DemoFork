using BulbaCourses.PracticalMaterialsTests.Logic.Models.Join;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Users;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.TestsBase
{
    public class MTestBase_MainInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MUser Author { get; set; }

        public IEnumerable<MJoin_TestWithQuestions> Join_TestWithQuestions { get; set; }
    }
}
