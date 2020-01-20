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
    class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator(ICoursesService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Name).NotNull().MinimumLength(5).WithMessage("Name must be more than 5 characters");

            RuleSet("UpdateCourse", () =>
            {
                RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
            });
        }
    }
}
