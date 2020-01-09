using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Interfaсe
{
    public interface IService_AnswerVariant : IDisposable
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
