using BulbaCourses.PracticalMaterialsTests.Data.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest
{
    public class MReaderChoice_SetOrder
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfo ReaderChoice_MainInfoDb { get; set; }

        // ------------ Test

        public int Question_SetOrderDb_Id { get; set; }

        public int AnswerVariant_SetOrderDb_Id { get; set; }

        public int OrderKey { get; set; }
    }
}