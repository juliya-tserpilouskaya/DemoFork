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
    public class PresentationValidator : AbstractValidator<Presentation>
    {
        public PresentationValidator(IPresentationsService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Title).NotEmpty().MinimumLength(5).WithMessage("Title must be more than 5 characters");

            RuleSet("UpdatePresentation", () =>
            {
                RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
            });
        }
    }
}
