using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest
{
    public class MReaderChoice_SetOrderDb
    {
        public int Id { get; set; }

        // ------------ ReaderChoice

        public int ReaderChoice_MainInfoDb_Id { get; set; }

        public MReaderChoice_MainInfoDb ReaderChoice_MainInfoDb { get; set; }

        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public int Question_SetOrderDb_Id { get; set; }

        public int AnswerVariant_SetOrderDb_Id { get; set; }

        public int OrderKey { get; set; }
    }
}