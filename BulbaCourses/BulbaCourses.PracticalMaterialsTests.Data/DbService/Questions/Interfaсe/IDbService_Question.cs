using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbService.Questions.Interfaсe
{
    public interface IDbService_Question
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
