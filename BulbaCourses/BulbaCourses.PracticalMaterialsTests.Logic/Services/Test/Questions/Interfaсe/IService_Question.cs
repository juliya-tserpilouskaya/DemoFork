using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe
{
    public interface IService_Question : IDisposable
    {
        /// <summary>
        /// Сhecking the results of the answer to the question
        /// </summary>
        /// <param name="Current_Test_MainInfo"></param>
        /// <param name="ReaderChoice_MainInfo"></param>
        /// <returns></returns>
        int CheckQuestion(MTest_MainInfo Current_Test_MainInfo, MReaderChoice_MainInfo ReaderChoice_MainInfo);
    }
}