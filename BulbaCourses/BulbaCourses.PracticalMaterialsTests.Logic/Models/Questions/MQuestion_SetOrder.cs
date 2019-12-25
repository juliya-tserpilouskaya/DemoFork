using BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Users;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions
{
    /// <summary>
    /// Question, where user need to arrange the elements in the correct order
    /// </summary>
    public class MQuestion_SetOrder
    {
        public int Id { get; set; }        

        public MUser Author { get; set; }

        public IEnumerable<MAnswerVariants_SetOrder> AnswerVariants { get; set; }
    }
}
