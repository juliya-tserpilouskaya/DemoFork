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
    class AudioValidator : AbstractValidator<AudioWeb>
    {
        public AudioValidator(IAudioService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddAudio", () =>
            {
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
                RuleFor(c => c.Name).MustAsync((async (title, token) => !(await service.ExistsNameAsync(title))));
                RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.");
                RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.");
                RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.");
            });
            RuleSet("UpdateAudio", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
                RuleFor(c => c.Name).NotEmpty().WithMessage("User login is required.");
            });
            RuleSet("DeleteAudio", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
                RuleFor(x => x.Course).NotEmpty();
                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsIdAsync(title))));
            });
        }
    }
}
