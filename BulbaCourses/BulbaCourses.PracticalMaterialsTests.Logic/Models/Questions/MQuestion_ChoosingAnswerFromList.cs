using BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions
{
    /// <summary>
    /// Question, where user need to find one or more correct answer from list
    /// </summary>
    public class MQuestion_ChoosingAnswerFromList
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public MUser Author { get; set; }

        public IEnumerable<MAnswerVariant_ChoosingAnswerFromList> AnswerVariants { get; set; }
    }
}
