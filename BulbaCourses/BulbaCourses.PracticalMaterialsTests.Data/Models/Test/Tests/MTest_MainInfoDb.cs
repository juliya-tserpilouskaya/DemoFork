using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Test
{
    public class MTest_MainInfoDb
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public ICollection<MQuestion_ChoosingAnswerFromListDb> Questions_ChoosingAnswerFromList { get; set; }

        public ICollection<MQuestion_SetIntoMissingElementsDb> Questions_SetIntoMissingElements { get; set; }

        public ICollection<MQuestion_SetOrderDb> Questions_SetOrder { get; set; }
    }
}
