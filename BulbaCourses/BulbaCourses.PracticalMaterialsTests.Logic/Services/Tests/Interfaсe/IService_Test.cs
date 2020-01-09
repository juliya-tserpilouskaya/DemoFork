using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe
{
    public interface IService_Test : IDisposable
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
