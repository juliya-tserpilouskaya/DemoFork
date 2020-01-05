using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.Users
{
    public class Validator_User : AbstractValidator<MUserDb>
    {
        public Validator_User()
        {
            RuleFor(x => x.Login)
                //.Cascade(CascadeMode.StopOnFirstFailure)               
                .Length(4, 50)
                .WithMessage("Длина Login должна быть от 4 до 50 символов")
                .Must(x => x.All(Char.IsLetter))
                .WithMessage("Login должен содержать только буквы");
            RuleFor(x => x.Password)
                //.Cascade(CascadeMode.StopOnFirstFailure)              
                .Length(4, 50)
                .WithMessage("Длина пароля должны быть от 4 до 50 символов")
                .Matches(@"^(?=.*[a-zа-я])(?=.*[A-ZА-Я])(?=.*[0-9])(?=.*[^a-zA-Z0-9])")
                .WithMessage("Введенный пароль должен содержать как минимум одну цифру, один символ, по одной печатной и стройчной букве латинского алфавита.");
            RuleFor(x => x.Email)
                //.Cascade(CascadeMode.StopOnFirstFailure)
                .Length(8, 50)
                .WithMessage("Длина Email должны быть от 8 до 50 символов")
                .EmailAddress()
                .WithMessage("формат Email должен быть xxx@xxx.xx");
        }
    }
}