using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.User;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test
{
    public class MTest_MainInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // ------------ Content

        public IList<MQuestion_ChoosingAnswerFromList> Questions_ChoosingAnswerFromList { get; set; }        

        public IList<MQuestion_SetOrder> Questions_SetOrder { get; set; }
    }
}
