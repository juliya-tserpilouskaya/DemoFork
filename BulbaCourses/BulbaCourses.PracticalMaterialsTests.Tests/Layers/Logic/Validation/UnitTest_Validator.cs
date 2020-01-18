using System;
using NUnit.Framework;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Logic
{
    [TestFixture]
    class UnitTest_Validator
    {
        [Test]
        [TestCase("  ")]
        [Description("Тестовый метод для валидации данных во время добавления нового теста")]
        public void InsertNewDataFromTest(string Name)
        {
            Validator_Test_MainInfo VTest_MainInfo = new Validator_Test_MainInfo();

            MTest_MainInfo Test_MainInfo = new MTest_MainInfo()
            {
                Name = Name
            };

            var Result = VTest_MainInfo.Validate(Test_MainInfo);

            if (Result.IsValid == false)
            {
                foreach (var fail in Result.Errors)
                {
                    Assert.Warn($"{fail.PropertyName} : {fail.ErrorMessage}");
                }
            }
        }
    }
}