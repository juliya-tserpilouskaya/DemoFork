using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Tests
{
    public class MTest_MainInfoDb
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public ICollection<MQuestion_ChoosingAnswerFromListDb> Question_ChoosingAnswerFromList { get; set; }

        public ICollection<MQuestion_SetIntoMissingElementsDb> Question_SetIntoMissingElements { get; set; }

        public ICollection<MQuestion_SetOrderDb> Question_SetOrder { get; set; }
    }
}
