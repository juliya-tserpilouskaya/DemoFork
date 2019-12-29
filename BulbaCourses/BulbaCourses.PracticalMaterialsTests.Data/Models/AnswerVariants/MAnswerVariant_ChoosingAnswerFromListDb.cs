using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants
{   
    public class MAnswerVariant_ChoosingAnswerFromListDb    
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public bool IsCorrectAnswer { get; set; }

        public int Question_ChoosingAnswerFromListDb_Id { get; set; }

        public MQuestion_ChoosingAnswerFromListDb Question_ChoosingAnswerFromListDb { get; set; }
    }
}
