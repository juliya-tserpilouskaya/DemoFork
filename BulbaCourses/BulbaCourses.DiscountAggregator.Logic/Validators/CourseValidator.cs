using BulbaCourses.DiscountAggregator.Logic.Models;
using FluentValidation;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleSet("AddCourse", () =>
            {
                 RuleFor(x => x.Id).Null().WithMessage("Id must be null");
            });
            RuleSet("UpdateCourse", () =>
            {
                 RuleFor(x => x.Id).NotNull().WithMessage("Id must be not null");              
            });

            RuleFor(x => x.Price).GreaterThan(0.0);
            RuleFor(x => x.OldPrice).GreaterThan(0.0);
            RuleFor(x => x.Discount).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title must be not empty");
            RuleFor(x => x.Domain).NotEmpty().WithMessage("Domain must be not empty");
            RuleFor(x => x.URL).NotEmpty().WithMessage("URL must be not empty");
        }
    }
}
