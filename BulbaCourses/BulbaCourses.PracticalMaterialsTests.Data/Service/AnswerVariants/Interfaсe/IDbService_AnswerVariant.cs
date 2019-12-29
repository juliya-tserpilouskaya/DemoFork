using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.Service.AnswerVariants.Interfaсe
{
    public interface IDbService_AnswerVariant
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
