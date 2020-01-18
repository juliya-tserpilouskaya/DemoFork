using System;
using System.Linq;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test.AnswerVariants
{
    public class Validator_AnswerVariant_ChoosingAnswerFromList : AbstractValidator<MAnswerVariant_ChoosingAnswerFromList>
    {
        public Validator_AnswerVariant_ChoosingAnswerFromList()
        {
            RuleFor(x => x.AnswerText)
                //.Cascade(CascadeMode.StopOnFirstFailure)                
                .Length(20, 50).WithMessage("Длина QuestionText должна быть от 20 до 50 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Наименование не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Наименование не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Наименование не может быть только из пробелов");
        }
    }
}
