using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.User
{
    public class MUser_TestReaderDb
    {        
        public string Id { get; set; }

        public ICollection<MReaderChoice_MainInfoDb> ResultsOfTheTest { get; set; }
    }
}
