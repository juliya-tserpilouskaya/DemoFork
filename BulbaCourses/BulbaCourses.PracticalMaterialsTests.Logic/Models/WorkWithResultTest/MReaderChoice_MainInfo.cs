using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.User;
using System;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest
{
    public class MReaderChoice_MainInfo
    {
        public int Id { get; set; }

        // ------------ CommonInformation

        public int NumberOfAttempt { get; set; }

        public string ResultTest { get; set; }

        public DateTime DatePassed { get; set; }

        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public MTest_MainInfo Test_MainInfo { get; set; }

        // ------------ User

        public string User_TestReaderDb_Id { get; set; }

        public MUser_TestReader User_TestReader { get; set; }

        // ------------ ResultOfTheTest

        public ICollection<MReaderChoice_ChoosingAnswerFromList> ReaderChoices_ChoosingAnswerFromList { get; set; }

        public ICollection<MReaderChoice_SetOrder> ReaderChoices_SetOrder { get; set; }
    }
}