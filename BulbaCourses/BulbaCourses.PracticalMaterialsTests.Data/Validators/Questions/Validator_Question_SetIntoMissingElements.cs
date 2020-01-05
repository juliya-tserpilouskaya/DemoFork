using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.Questions
{
    public class Validator_Question_SetIntoMissingElements : AbstractValidator<MQuestion_SetIntoMissingElementsDb>
    {
        public Validator_Question_SetIntoMissingElements()
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
