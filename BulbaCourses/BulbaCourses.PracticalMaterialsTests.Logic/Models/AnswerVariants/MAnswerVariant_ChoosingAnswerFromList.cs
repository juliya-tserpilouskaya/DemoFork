using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants
{   
    public class MAnswerVariant_ChoosingAnswerFromList
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public bool IsCorrectAnswer { get; set; }
    }
}
