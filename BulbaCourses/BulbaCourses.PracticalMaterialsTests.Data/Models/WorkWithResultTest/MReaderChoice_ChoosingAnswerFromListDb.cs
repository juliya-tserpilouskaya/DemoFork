using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest
{
    public class MReaderChoice_ChoosingAnswerFromListDb
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfoDb ReaderChoice_MainInfoDb { get; set; }

        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public int Question_ChoosingAnswerFromList_Id { get; set; }

        public int AnswerVariant_ChoosingAnswerFromListDb_Id { get; set; }

        public bool IsChoice { get; set; }
    }
}
