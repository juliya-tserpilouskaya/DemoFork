using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;

namespace BulbaCourses.Podcasts.Web.Validators
{
    class CommentValidator : AbstractValidator<CommentWeb>
    {
        public CommentValidator(ICourseService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddComment", () =>
            {
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));
                RuleFor(x => x.Text).NotEmpty().MaximumLength(255).MinimumLength(3);
                RuleFor(x => x.Id).Must((id) => !(service.Exists(id)));

            });
            RuleSet("UpdateComment", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Id).Must((id) => (service.Exists(id)));
                RuleFor(x => x.Text).NotEmpty().MaximumLength(255).MinimumLength(3);
            });
            RuleSet("DeleteComment", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Id).Must((id) => (service.Exists(id)));
            });

        }
    }
}