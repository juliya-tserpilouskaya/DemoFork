using BulbaCourses.PracticalMaterialsTests.Data.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest
{
    public class MReaderChoice_SetOrderDb
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfoDb ReaderChoice_MainInfoDb { get; set; }

        // ------------ User

        public string User_TestReaderDb_Id { get; set; }

        public MUser_TestReaderDb User_TestReader { get; set; }

        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public int Question_SetOrderDb_Id { get; set; }

        public int AnswerVariant_SetOrderDb_Id { get; set; }

        public int OrderKey { get; set; }
    }
}