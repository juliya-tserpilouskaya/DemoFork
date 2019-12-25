using BulbaCourses.PracticalMaterialsTests.Data.Models.Join;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Tests
{
    public class MTest_MainInfoDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MUserDb Author { get; set; }

        public IEnumerable<MJoin_TestWithQuestionsDb> Join_TestWithQuestions { get; set; }
    }
}
