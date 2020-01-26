using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.User;
using System;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Test
{
    public class MTest_MainInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreate { get; set; }

        // ------------ Content

        public ICollection<MQuestion_ChoosingAnswerFromList> Questions_ChoosingAnswerFromList { get; set; }        

        public ICollection<MQuestion_SetOrder> Questions_SetOrder { get; set; }
    }
}
