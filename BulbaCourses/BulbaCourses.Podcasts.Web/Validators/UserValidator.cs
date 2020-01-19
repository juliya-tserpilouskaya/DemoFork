using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Web.Models;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;

namespace BulbaCourses.Podcasts.Web.Validators
{
    class UserValidator : AbstractValidator<UserWeb>
    {
        public UserValidator(IUserService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddUser", () =>
            {
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));
                RuleFor(c => c.Name).MustAsync((async (title, token) => !(await service.ExistsAsync(title))));
                RuleFor(c => c.Name).NotEmpty().WithMessage("User login is required.");
                RuleFor(c => c.Name).MinimumLength(5).WithMessage("Login must contain minimum 5 characters.");
                RuleFor(c => c.Name).MaximumLength(20).WithMessage("Login must contain maximum 20 characters.");
            });
            RuleSet("UpdateUser", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(c => c.Name).MustAsync((async (title, token) => !(await service.ExistsAsync(title))));
                RuleFor(c => c.Name).NotEmpty().WithMessage("User login is required.");
            });
            RuleSet("DeleteUser", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(c => c.Name).MustAsync((async (title, token) => !(await service.ExistsAsync(title))));
            });
        }
    }
}
