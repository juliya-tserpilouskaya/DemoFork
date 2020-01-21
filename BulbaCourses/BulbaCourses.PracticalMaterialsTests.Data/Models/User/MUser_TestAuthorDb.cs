using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.User
{
    public class MUser_TestAuthorDb
    {        
        public string Id { get; set; }        

        public ICollection<MTest_MainInfoDb> CreateTests { get; set; }
    }
}
