using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using System;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.WorkWithResultTest.Interface
{
    public interface IService_WorkWithResultTest : IDisposable
    {
        MResultRequest<string> Add(MReaderChoice_MainInfoDb ResultOfTheTestDb);

        Task<MResultRequest<string>> AddAsync(MReaderChoice_MainInfoDb ResultOfTheTestDb);
    }
}
