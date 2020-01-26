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
            RuleFor(_ => _.Name).NotNull().MinimumLength(5).WithMessage("Name of an item must be more than 5 characters");
        }
    }
}