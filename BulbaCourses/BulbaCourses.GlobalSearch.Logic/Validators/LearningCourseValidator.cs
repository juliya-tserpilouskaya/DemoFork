using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    class LearningCourseValidator : AbstractValidator<LearningCourseDTO>
    {
        public LearningCourseValidator(ILearningCourseService service)
        {
            RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Learning course must have an author");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course must have a name");
            RuleFor(x => x.Items).NotEmpty().WithMessage("Course must have at least one item");
            //RuleFor(x => x.Id).MustAsync((async
            //    (id, token) => !(await service.AnyAsync
            //    (id).ConfigureAwait(false))));
        }
    }
}
