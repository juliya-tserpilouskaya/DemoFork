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
            RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Learning course must have an author");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course must have a name");
            RuleForEach(x => x.Items).SetValidator(new LearningCourseItemValidator());
            //RuleFor(x => x.Id).MustAsync((async
            //    (id, token) => !(await service.AnyAsync
            //    (id).ConfigureAwait(false))));
        }
    }
}
