using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models.UserViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class ChangePasswordViewValidator : AbstractValidator<ChangePasswordView>
    {
        public ChangePasswordViewValidator(IUserService service)
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("Id must be not empty or null");
            RuleFor(c => c.OldPassword).NotEmpty().WithMessage("Password is required.");
            RuleFor(c => c.OldPassword).MustAsync((async (user, pass, token) => !(await service.CheckPasswordAsync(user.UserId, pass))))
                .WithMessage("Email already taken");

            RuleFor(c => c.NewPassword).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
                .Matches("[A-Z]").Matches("[a-z]").Matches("[a-z]").Matches("[0-9]").Matches("[^a-zA-Z0-9]")
                .WithMessage("Regular Expression Password");

            RuleFor(c => c.ConfirmNewPassword).Equal(c => c.NewPassword).WithMessage("Password and confirmation password do not match");
        }
    }
}