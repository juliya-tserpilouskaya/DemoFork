using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests
{
    public class MTest_MainInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public ICollection<MQuestion_ChoosingAnswerFromList> Question_ChoosingAnswerFromList { get; set; }

        public ICollection<MQuestion_SetIntoMissingElements> Question_SetIntoMissingElements { get; set; }

        public ICollection<MQuestion_SetOrder> Question_SetOrder { get; set; }
    }
}
