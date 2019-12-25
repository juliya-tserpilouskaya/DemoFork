using BulbaCourses.PracticalMaterialsTests.Data.DbService.Questions.Interfaсe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.TestAPI
{
    public class TestAPIClass
    {
        IDbService_Question Question;

        public TestAPIClass(IDbService_Question Question)
        {
            this.Question = Question;
        }

        public string GetQuestionById(int Id)
        {
            Question.GetQuestonById(Id);

            return "Получил JSON с вопросом";
        }
    }
}
