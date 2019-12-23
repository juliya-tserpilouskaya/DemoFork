using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models.UserViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class UserLoginViewValidator : AbstractValidator<UserLoginView>
    {
        public UserLoginViewValidator(IUserService service)
        {
            RuleFor(c => c.Login).NotEmpty().WithMessage("User login is required.");
            RuleFor(c => c.Login).MaximumLength(20).WithMessage("Login must contain maximum 20 characters.");
            RuleFor(c => c.Login).MustAsync((async (login, token) => (await service.CheckLoginAsync(login))))
                .WithMessage("Wrong Login");

            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
                .MaximumLength(20).WithMessage("Password must contain maximum 20 characters.")
                .Matches("[A-Z]").Matches("[a-z]").Matches("[a-z]").Matches("[0-9]").Matches("[^a-zA-Z0-9]")
                .WithMessage("Regular Expression Password");

            RuleFor(c => c.RememberMe).NotEmpty().WithMessage("Remember me?");
        }
    }
}