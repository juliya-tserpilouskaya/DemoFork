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
            //RuleSet("Insert_New_Test_MainInfo", () => {
                RuleFor(x => x.Name)
                //.Cascade(CascadeMode.StopOnFirstFailure)                
                .Length(5, 50)
                .WithMessage("Длина Name должна быть от 5 до 50 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Наименование не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Наименование не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Наименование не может быть только из пробелов");
           // });
            
        }
    }
}
