using BulbaCourses.PracticalMaterialsTests.Data.Service.Questions.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Data.Service.Questions.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.TestAPI
{
    public class TestAPIClass
    {
        public TestAPIClass()
        {            
        }

        public string GetQuestionById(int Id)
        {
            DbService_Question_ChoosingAnswerFromList dd = new DbService_Question_ChoosingAnswerFromList();

            dd.GetQuestonById(5);



            return "Получил JSON с вопросом";
        }
    }
}
