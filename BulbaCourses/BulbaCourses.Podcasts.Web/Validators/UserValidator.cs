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
                RuleFor(x => x.Name).Must(((name) => !(service.Exists(name))));
            });
            RuleSet("UpdateUser", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Name).Must(((name) => (service.Exists(name))));
            });
            RuleSet("DeleteUser", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Name).Must(((name) => (service.Exists(name))));
            });

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
