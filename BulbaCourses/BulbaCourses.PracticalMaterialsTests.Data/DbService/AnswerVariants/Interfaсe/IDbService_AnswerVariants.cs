using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbService.AnswerVariants.Interfaсe
{
    public interface IDbService_AnswerVariants
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
