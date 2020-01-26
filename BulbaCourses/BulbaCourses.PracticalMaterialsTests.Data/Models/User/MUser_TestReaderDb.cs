using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using System;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.User
{
    /// <summary>
    /// User who passes tests
    /// </summary>
    public class MUser_TestReaderDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FIO { get; set; }

        public ICollection<MReaderChoice_MainInfoDb> ResultsOfTheTest { get; set; }
    }
}