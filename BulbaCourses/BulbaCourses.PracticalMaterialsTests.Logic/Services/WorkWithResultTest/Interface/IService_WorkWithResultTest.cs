using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using System;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.WorkWithResultTest.Interface
{
    public interface IService_WorkWithResultTest : IDisposable
    {
        MResultRequest<string> Add(MReaderChoice_MainInfo ResultOfTheTest);

        Task<MResultRequest<string>> AddAsync(MReaderChoice_MainInfo ResultOfTheTest);
    }
}
