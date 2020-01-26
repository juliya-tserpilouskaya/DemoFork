using System;
using System.Linq;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test
{
    public class Validator_Test_MainInfo : AbstractValidator<MTest_MainInfo>
    {
        public Validator_Test_MainInfo()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .Length(5, 50).WithMessage("Длина Name должна быть от 5 до 50 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Наименование не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Наименование не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Наименование не может быть только из пробелов");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Длина описания должна быть до 500 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Описания не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Описания не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Описания не может быть только из пробелов");
        }
    }
}
