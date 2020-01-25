using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions
{
    /// <summary>
    /// Question, where user need to arrange the elements in the correct order
    /// </summary>
    public class MQuestion_SetOrderDb
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int SortKey { get; set; }

        public int Test_MainInfoDb_Id { get; set; }

        public MTest_MainInfoDb Test_MainInfoDb { get; set; }

        public ICollection<MAnswerVariant_SetOrderDb> AnswerVariants { get; set; }
    }
}
