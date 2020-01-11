using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Interfaсe
{
    public interface IService_AnswerVariant : IDisposable
    {
        void GetAnswerById(int Id);

        void AddAnswer();

        void DropAnswerById(int Id);
    }
}
