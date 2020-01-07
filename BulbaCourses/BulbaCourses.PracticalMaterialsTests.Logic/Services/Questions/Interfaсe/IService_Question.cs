using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Interfaсe
{
    public interface IService_Question
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
