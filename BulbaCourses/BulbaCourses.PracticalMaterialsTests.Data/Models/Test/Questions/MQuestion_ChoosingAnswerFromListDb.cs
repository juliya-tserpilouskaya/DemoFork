using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions
{
    /// <summary>
    /// Question, where user need to find one or more correct answer from list
    /// </summary>
    public class MQuestion_ChoosingAnswerFromListDb
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int SortKey { get; set; }

        public int Test_MainInfoDb_Id { get; set; }

        public MTest_MainInfoDb Test_MainInfoDb { get; set; }

        public ICollection<MAnswerVariant_ChoosingAnswerFromListDb> AnswerVariants { get; set; }        
    }
}
