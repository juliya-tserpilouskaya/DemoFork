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
    class ContentValidator : AbstractValidator<ContentWeb>
    {
        public ContentValidator(IContentService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddContent", () =>
            {
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));
                RuleFor(x => x.Audio).NotEmpty();
                RuleFor(x => x.Data).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
            });
            RuleSet("UpdateContent", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Audio).NotEmpty();
                RuleFor(x => x.Data).Empty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
            });
            RuleSet("DeleteContent", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Audio).NotEmpty();
                RuleFor(x => x.Data).Empty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
            });
        }
    }
}
