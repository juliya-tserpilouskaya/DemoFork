using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class LearningCourseValidator : AbstractValidator<LearningCourseDTO>
    {
        public LearningCourseValidator()
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Name).NotNull().MinimumLength(5).WithMessage("Name must be more than 5 characters");

            RuleSet("UpdateCourse", () =>
            {
                RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
            });

            //RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Learning course must have an author");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Learning course must have a category");
            RuleForEach(x => x.Items).SetValidator(new LearningCourseItemValidator());
            //RuleFor(x => x.Id).MustAsync((async
            //    (id, token) => !(await service.AnyAsync
            //    (id).ConfigureAwait(false))));
        }
    }
}
