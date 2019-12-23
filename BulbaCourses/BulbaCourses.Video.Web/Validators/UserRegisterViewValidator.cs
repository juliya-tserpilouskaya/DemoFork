using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models.UserViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class UserRegisterViewValidator : AbstractValidator<UserRegisterView>
    {
        public UserRegisterViewValidator(IUserService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c.UserId).Must(c => string.IsNullOrEmpty(c)).WithMessage("Id must be empty or null");

            RuleFor(c => c.Name).NotEmpty().WithMessage("User name is required.");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("User lastname is required.");

            RuleFor(c => c.Login).NotEmpty().WithMessage("User login is required.");
            RuleFor(c => c.Login).MustAsync((async (title, token) => !(await service.ExistLoginAsync(title))))
                .WithMessage("Login already taken");
            RuleFor(c => c.Login).MaximumLength(20).WithMessage("Login must contain maximum 20 characters.");

            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(c => c.Email).MustAsync((async (title, token) => !(await service.ExistEmailAsync(title))))
                .WithMessage("Email already taken");

            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
                .Matches("[A-Z]").Matches("[a-z]").Matches("[a-z]").Matches("[0-9]").Matches("[^a-zA-Z0-9]")
                .WithMessage("Regular Expression Password");

            RuleFor(c => c.ConfirmPassword).Equal(c => c.Password).WithMessage("Password and confirmation password do not match");
        }
    }
}