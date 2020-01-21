using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions
{
    /// <summary>
    /// Question, where user need to set correct elements into question text
    /// </summary>
    public class MQuestion_SetIntoMissingElements
    {
        public string QuestionText { get; set; }

        public int SortKey { get; set; }                

        public ICollection<MAnswerVariant_SetIntoMissingElements> AnswerVariants { get; set; }
    }
}
