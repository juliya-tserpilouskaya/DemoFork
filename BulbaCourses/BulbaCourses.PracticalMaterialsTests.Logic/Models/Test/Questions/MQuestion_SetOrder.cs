using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions
{
    /// <summary>
    /// Question, where user need to arrange the elements in the correct order
    /// </summary>
    public class MQuestion_SetOrder
    {
        public string QuestionText { get; set; }

        public int SortKey { get; set; }                

        public IList<MAnswerVariant_SetOrder> AnswerVariants { get; set; }
    }
}
