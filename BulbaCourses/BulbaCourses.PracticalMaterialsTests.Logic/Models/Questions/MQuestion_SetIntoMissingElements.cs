using BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions
{
    /// <summary>
    /// Question, where user need to set correct elements into question text
    /// </summary>
    public class MQuestion_SetIntoMissingElements
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int SortKey { get; set; }        

        public MTest_MainInfo Test_MainInfo { get; set; }

        public ICollection<MAnswerVariant_SetIntoMissingElements> AnswerVariants { get; set; }
    }
}
