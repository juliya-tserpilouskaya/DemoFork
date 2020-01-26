using BulbaCourses.PracticalMaterialsTests.Data.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest
{
    public class MReaderChoice_ChoosingAnswerFromList
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfo ReaderChoice_MainInfo { get; set; }

        // ------------ User

        public string User_TestReaderDb_Id { get; set; }

        public MUser_TestReaderDb User_TestReader { get; set; }


        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public int Question_ChoosingAnswerFromList_Id { get; set; }

        public int User_AnswerVariant_ChoosingAnswerFromListDb_Id { get; set; }

        public int Correct_AnswerVariant_ChoosingAnswerFromListDb_Id { get; set; }

        public bool IsChoice { get; set; }
    }
}
