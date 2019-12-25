using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbService.Question.Interfaсe
{
    public interface IQuestionDbService
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
