using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.User
{
    public class MUser_TestReader
    {
        public int Id { get; set; }

        public ICollection<MReaderChoice_MainInfo> ResultsOfTheTest { get; set; }
    }
}
