﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using BulbaCourses.PracticalMaterialsTests.Data.Validators.Users;
using NUnit.Framework;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Data
{
    [TestFixture]
    class UnitTest_Validator
    {
        [Test]
        [TestCaseSource("ValuesForUserData")]
        [Description("Тестовый метод для валидации данных во время добавления нового пользователя")]
        public void InsertNewDataFromUsers(string Login, string Password, string Email)
        {
            Validator_User VUser = new Validator_User();

            MUserDb User = new MUserDb()
            {
                Login = Login,
                Password = Password,
                Email = Email
            };
          
            var Result = VUser.Validate(User);

            if (Result.IsValid == false)
            {
                foreach (var fail in Result.Errors)
                {
                    Assert.Warn($"{fail.PropertyName} : {fail.ErrorMessage}");
                }
            }
        }

        // Тестовые данные для полей User
        static object[] ValuesForUserData =
        {
            new object[] { "1", "", "" },
            new object[] { "Romanenko", "!Aa12345", "romanenko@gmail.com" }
        };
    }
}