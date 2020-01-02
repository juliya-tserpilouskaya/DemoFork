using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants
{   
    public class MAnswerVariant_SetOrderDb
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public int CorrectOrderKey { get; set; }

        public int Question_SetOrderDb_Id { get; set; }

        public MQuestion_SetOrderDb Question_SetOrderDb { get; set; }
    }
}
