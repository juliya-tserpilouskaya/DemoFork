using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Questions
{
    /// <summary>
    /// Question, where user need to set correct elements into question text
    /// </summary>
    public class MQuestion_SetIntoMissingElementsDb
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int SortKey { get; set; }

        public int Test_MainInfoDb_Id { get; set; }

        public MTest_MainInfoDb Test_MainInfoDb { get; set; }

        public ICollection<MAnswerVariant_SetIntoMissingElementsDb> AnswerVariants { get; set; }
    }
}
