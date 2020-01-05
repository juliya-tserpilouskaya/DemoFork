using BulbaCourses.Youtube.Logic.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Logic.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("Id must be not null");
            RuleFor(v => v.Login).Must(x => !string.IsNullOrEmpty(x)).MaximumLength(100)
                .WithMessage("Login must be not null, length no more than 100 symbols.");
            RuleFor(v => v.Password).NotNull().MinimumLength(8).MaximumLength(100)
                .Must(p=> Regex.IsMatch(p,@"\w+")).Must(p => Regex.IsMatch(p, @"\d+")) 
                .WithMessage("Password must be not null, must contain word characters and at least one digit," +
                " length more than 8 symbols and less than 100 symbols.");
            RuleFor(x => x.FirstName).Must(x => !string.IsNullOrEmpty(x)).MaximumLength(100)
                .WithMessage("FirstName must be not null, length no more than 100 symbols.");
            RuleFor(x => x.LastName).Must(x => !string.IsNullOrEmpty(x)).MaximumLength(100)
                .WithMessage("LastName must be not null, length no more than 100 symbols.");
            RuleFor(x => x.FullName).Must(x => !string.IsNullOrEmpty(x)).MaximumLength(200)
                .WithMessage("FullName must be not null, length no more than 200 symbols.");
            RuleFor(x => x.NumberPhone).NotNull().Must(p => Regex.IsMatch(p,@"\+\d{3}\(\d{2}\)\d{3}-\d{2}-\d{2}"))
                .WithMessage("NumberPhone must be not null, must have the following format: +xxx(xx)xxx-xx-xx ");
            RuleFor(x => x.Email).NotNull().EmailAddress()
                .WithMessage("Email must be not null, must have the following format: somebody@example.com ");
            RuleFor(x => x.ReserveEmail).NotNull().EmailAddress()
                .WithMessage("ReserveEmail must have the following format: somebody@example.com ");
        }
    }
}
