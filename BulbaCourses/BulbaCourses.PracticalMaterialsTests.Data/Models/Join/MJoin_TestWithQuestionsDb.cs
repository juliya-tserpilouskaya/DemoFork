using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Join
{
    public class MJoin_TestWithQuestionsDb
    {
        public MTest_MainInfoDb Test_Info { get; set; }

        public int QuestionType { get; set; }

        public int SortKey { get; set; }

        public MQuestion_ChoosingAnswerFromListDb Question_ChoosingAnswerFromList { get; set; }

        public MQuestion_SetOrderDb Question_SetOrder { get; set; }

        public MQuestion_SetIntoMissingElementsDb Question_SetIntoMissingElements { get; set; }
    }
}
