using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.AnswerVariants.Interfaсe
{
    public interface IService_AnswerVariant : IDisposable
    {
        void GetAnswerById(int Id);

        void AddAnswer();

        void DropAnswerById(int Id);
    }
}
