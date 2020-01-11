using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe
{
    public interface IService_Test : IDisposable
    {
        MTest_MainInfo GetTestById(int Id);

        void AddTest();

        void DropTestById(int Id);
    }
}
