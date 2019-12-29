using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Questions
{
    /// <summary>
    /// Question, where user need to find one or more correct answer from list
    /// </summary>
    public class MQuestion_ChoosingAnswerFromListDb
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public MUserDb Author { get; set; }

        public ICollection<MAnswerVariant_ChoosingAnswerFromListDb> AnswerVariants { get; set; }
    }
}
