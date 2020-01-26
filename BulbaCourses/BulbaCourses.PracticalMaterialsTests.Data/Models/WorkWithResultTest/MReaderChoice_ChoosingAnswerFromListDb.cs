using BulbaCourses.PracticalMaterialsTests.Data.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest
{
    public class MReaderChoice_ChoosingAnswerFromListDb
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfoDb ReaderChoice_MainInfoDb { get; set; }

        // ------------ Test

        public int Question_ChoosingAnswerFromList_Id { get; set; }

        public int AnswerVariant_ChoosingAnswerFromList_Id { get; set; }
    }
}
