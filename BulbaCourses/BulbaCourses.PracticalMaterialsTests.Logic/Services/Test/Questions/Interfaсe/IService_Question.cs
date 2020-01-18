using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe
{
    public interface IService_Question : IDisposable
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
