using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class UserProfileViewValidator : AbstractValidator<UserProfileView>
    {
        public UserProfileViewValidator(IUserService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddUser", () => {

                RuleFor(c => c.Login).NotEmpty().WithMessage("User login is required.");
                RuleFor(c => c.Login).MinimumLength(5).WithMessage("Login must contain minimum 5 characters.");
                RuleFor(c => c.Login).MaximumLength(20).WithMessage("Login must contain maximum 20 characters.");
                RuleFor(c => c.SubscriptionType).IsInEnum();

            });
            
            RuleSet("UpdateUser", () => {

                RuleFor(c => c.Login).NotEmpty().WithMessage("User login is required.");
                RuleFor(c => c.Login).MinimumLength(5).WithMessage("Login must contain minimum 5 characters.");
                RuleFor(c => c.Login).MaximumLength(20).WithMessage("Login must contain maximum 20 characters.");
                RuleFor(c => c.SubscriptionType).IsInEnum();

            });

        }
    }
}