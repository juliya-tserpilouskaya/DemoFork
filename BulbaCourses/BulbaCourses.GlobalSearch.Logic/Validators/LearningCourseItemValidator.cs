using BulbaCourses.GlobalSearch.Logic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class LearningCourseItemValidator : AbstractValidator<LearningCourseItemDTO>
    {
        public LearningCourseItemValidator()
        {
            //RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            //RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Learning course must have an author");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course item must have a name");
        }
    }
}