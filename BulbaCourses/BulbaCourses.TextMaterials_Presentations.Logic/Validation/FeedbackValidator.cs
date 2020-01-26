using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;

namespace Presentations.Logic.Validation
{
    class FeedbackValidator : AbstractValidator<Feedback>
    {
        public FeedbackValidator(IFeedbacksService service)
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(_ => _.Text).NotEmpty().MinimumLength(5).WithMessage("Feedback must be more than 5 characters");
            RuleFor(_ => _.PresentationDBId).NotEmpty();

            RuleSet("UpdateFeedback", () =>
            {
                RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
            });
        }
    }
}
