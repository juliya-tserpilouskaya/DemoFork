using BulbaCourses.Video.Web.Models.UserViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class UserProfileViewValidator : AbstractValidator<UserProfileView>
    {
        public UserProfileViewValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id is required.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("User name is required.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("User lastname is required.");
            RuleFor(c => c.Login).NotEmpty().WithMessage("User login is required.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(c => c.AvatarPath).NotEmpty().WithMessage("Avatar is requried.");
            RuleFor(c => c.SubscriptionType).NotEmpty().WithMessage("Subscription is required.");

        }
    }
}