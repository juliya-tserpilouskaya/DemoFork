using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Test
{
    public class MTest_MainInfoDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // ------------ Content

        public ICollection<MQuestion_ChoosingAnswerFromListDb> Questions_ChoosingAnswerFromList { get; set; }        

        public ICollection<MQuestion_SetOrderDb> Questions_SetOrder { get; set; }

        // ------------ User

        public string User_TestAuthorDb_Id { get; set; }

        public MUser_TestAuthorDb User_TestAuthor { get; set; }
    }
}
