using System;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbService.Tests.Interfaсe
{
    public interface IDbService_Test
    {
        void GetQuestonById(int Id);

        void AddQuestion();

        void DropQuestionById(int Id);
    }
}
