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
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(x => x.Text).NotEmpty().MaximumLength(255).MinimumLength(3);
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));

            });
            RuleSet("UpdateComment", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => (await service.ExistsIdAsync(title))));
                RuleFor(x => x.Text).NotEmpty().MaximumLength(255).MinimumLength(3);
            });
            RuleSet("DeleteComment", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => (await service.ExistsIdAsync(title))));
            });

        }
    }
}