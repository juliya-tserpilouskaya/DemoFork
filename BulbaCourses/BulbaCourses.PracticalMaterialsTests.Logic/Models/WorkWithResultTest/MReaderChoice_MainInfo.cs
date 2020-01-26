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

        public string ResultTest { get; set; }

        public int CountRightAnswer { get; set; }

        public int CountQuestion { get; set; }

        // ------------ Test

        public int Test_MainInfo_Id { get; set; }

        public MTest_MainInfo Test_MainInfo { get; set; }

        // ------------ User

        public string User_TestReader_Id { get; set; }

        public MUser_TestReader User_TestReader { get; set; }

        public DateTime DatePassed { get; set; }

        public string TimeSpent { get; set; }

        public int HasPassed { get; set; }

        public int IsRepeat { get; set; }

        // ------------ ResultOfTheTest

        public ICollection<MReaderChoice_ChoosingAnswerFromList> ReaderChoices_ChoosingAnswerFromList { get; set; }

        public ICollection<MReaderChoice_SetOrder> MReaderChoices_SetOrder { get; set; }
    }
}