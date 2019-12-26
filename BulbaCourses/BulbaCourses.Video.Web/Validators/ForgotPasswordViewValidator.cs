using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models.UserViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class ForgotPasswordViewValidator : AbstractValidator<ForgotPasswordView>
    {
        public ForgotPasswordViewValidator(IUserService service)
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(c => c.Email).MustAsync((async (title, token) => !(await service.CheckEmailForLossingPass(title))))
                .WithMessage("There is no user with this Email");
        }
    }
}