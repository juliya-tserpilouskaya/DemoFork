using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants
{   
    public class MAnswerVariant_SetOrder
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public int CorrectOrderKey { get; set; }        

        public MQuestion_SetOrder Question_SetOrder { get; set; }
    }
}
