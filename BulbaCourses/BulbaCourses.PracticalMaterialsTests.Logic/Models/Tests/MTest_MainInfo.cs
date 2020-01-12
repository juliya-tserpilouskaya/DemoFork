using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests
{
    public class MTest_MainInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public ICollection<MQuestion_ChoosingAnswerFromList> Questions_ChoosingAnswerFromList { get; set; }

        public ICollection<MQuestion_SetIntoMissingElements> Questions_SetIntoMissingElements { get; set; }

        public ICollection<MQuestion_SetOrder> Questions_SetOrder { get; set; }
    }
}
