using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants
{   
    public class MAnswerVariant_SetOrderDb
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public int CorrectOrderKey { get; set; }
    }
}
