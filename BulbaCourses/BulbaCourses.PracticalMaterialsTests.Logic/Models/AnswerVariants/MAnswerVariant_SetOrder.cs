using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants
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
