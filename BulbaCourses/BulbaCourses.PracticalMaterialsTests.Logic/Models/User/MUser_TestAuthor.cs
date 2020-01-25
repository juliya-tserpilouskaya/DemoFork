using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.User
{
    public class MUser_TestAuthor
    {
        public int Id { get; set; }        

        public ICollection<MTest_MainInfo> CreateTests { get; set; }
    }
}
