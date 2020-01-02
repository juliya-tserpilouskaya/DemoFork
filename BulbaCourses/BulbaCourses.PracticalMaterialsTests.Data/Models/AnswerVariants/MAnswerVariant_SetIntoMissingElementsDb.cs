using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants
{    
    public class MAnswerVariant_SetIntoMissingElementsDb
    {
        public int Id { get; set; }

        public int Question_SetIntoMissingElementsDb_Id { get; set; }

        public MQuestion_SetIntoMissingElementsDb Question_SetIntoMissingElementsDb { get; set; }
    }
}
