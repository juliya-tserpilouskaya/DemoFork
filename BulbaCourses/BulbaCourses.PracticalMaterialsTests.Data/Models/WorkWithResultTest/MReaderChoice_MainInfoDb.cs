using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using System;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest
{
    public class MReaderChoice_MainInfoDb
    {
        public int Id { get; set; }

        // ------------ CommonInformation

        public string ResultTest { get; set; }

        public int CountRightAnswer { get; set; }

        public int CountQuestion { get; set; }

        // ------------ Test

        public int Test_MainInfoDb_Id { get; set; }

        public MTest_MainInfoDb Test_MainInfo { get; set; }

        // ------------ User

        public string User_TestReaderDb_Id { get; set; }

        public MUser_TestReaderDb User_TestReader { get; set; }

        public DateTime DatePassed { get; set; }

        public string TimeSpent { get; set; }

        public int HasPassed { get; set; }

        public int IsRepeat { get; set; }

        // ------------ ResultOfTheTest

        public ICollection<MReaderChoice_ChoosingAnswerFromListDb> ReaderChoices_ChoosingAnswerFromListDb { get; set; }

        public ICollection<MReaderChoice_SetOrderDb> MReaderChoices_SetOrderDb { get; set; }
    }
}