using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.Collections.Generic;

namespace BulbaCourses.PracticalMaterialsTests.Data.Models.Questions
{
    /// <summary>
    /// Question, where user need to arrange the elements in the correct order
    /// </summary>
    public class MQuestion_SetOrderDb
    {
        public int Id { get; set; }        

        public MUserDb Author { get; set; }

        public IEnumerable<MAnswerVariant_SetOrderDb> AnswerVariants { get; set; }
    }
}
