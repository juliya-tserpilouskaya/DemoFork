using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Service.Questions.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Service.Questions.Realization
{
    public class DbService_Question_ChoosingAnswerFromList : IDbService_Question
    {
        public void AddQuestion()
        {
            throw new NotImplementedException();
        }

        public void DropQuestionById(int Id)
        {
            throw new NotImplementedException();
        }

        public void GetQuestonById(int Id)
        {
            using (DbContext_Test cc = new DbContext_Test())
            { 
                string XXX = cc.User.Find(3).Email;                  
            }
        }
    }
}
