using System;
using System.Linq;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Validators.Questions
{
    public class Validator_Question_ChoosingAnswerFromList : AbstractValidator<MQuestion_ChoosingAnswerFromList>
    {
        public Validator_Question_ChoosingAnswerFromList()
        {
            RuleFor(x => x.QuestionText)
                //.Cascade(CascadeMode.StopOnFirstFailure)                
                .Length(20, 50)
                .WithMessage("Длина QuestionText должна быть от 20 до 50 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Наименование не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Наименование не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Наименование не может быть только из пробелов");
        }
    }
}
