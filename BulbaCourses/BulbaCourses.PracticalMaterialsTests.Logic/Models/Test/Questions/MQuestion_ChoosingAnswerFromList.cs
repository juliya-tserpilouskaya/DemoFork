using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions
{
    /// <summary>
    /// Question, where user need to find one or more correct answer from list
    /// </summary>
    public class MQuestion_ChoosingAnswerFromList
    {
        public string QuestionText { get; set; }

        public int SortKey { get; set; }                

        public ICollection<MAnswerVariant_ChoosingAnswerFromList> AnswerVariants { get; set; }        
    }
}