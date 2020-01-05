using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.Tests
{
    public class Validator_Test_MainInfo : AbstractValidator<MTest_MainInfoDb>
    {
        public Validator_Test_MainInfo()
        {
            RuleFor(x => x.Name)
                //.Cascade(CascadeMode.StopOnFirstFailure)                
                .Length(1, 50)
                .WithMessage("Длина Name должна быть от 1 до 50 символов");
        }

        protected void ValidTestName(string Name)
        {
            
        }
    }
}
