using BulbaCourses.PracticalMaterialsTests.Logic.Enum;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.TestsBase;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Join
{
    public class MJoin_TestWithQuestions
    {
        public MTestBase_MainInfo Test_Info { get; set; }

        public EQuestionType QuestionType { get; set; }

        public int SortKey { get; set; }

        public MQuestion_ChoosingAnswerFromList Question_ChoosingAnswerFromList { get; set; }

        public MQuestion_SetOrder Question_SetOrder { get; set; }

        public MQuestion_SetIntoMissingElements Question_SetIntoMissingElements { get; set; }
    }
}
