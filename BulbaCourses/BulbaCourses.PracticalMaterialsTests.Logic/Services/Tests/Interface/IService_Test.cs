using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using System;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interface
{
    public interface IService_Test : IDisposable
    {
        MTest_MainInfo GetById(int Id);

        Task<MTest_MainInfo> GetByIdAsync(int Id);

        int Add(MTest_MainInfo Test_MainInfo);

        Task<int> AddAsync(MTest_MainInfo Test_MainInfo);

        void DropById(int Id);

        void DropByIdAsync(int Id);
    }
}
