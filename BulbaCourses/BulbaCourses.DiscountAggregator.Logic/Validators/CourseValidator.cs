using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Logic.Models;
using FluentValidation;
using FluentValidation.Attributes;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be not empty");
            RuleFor(x => x.Id).NotNull().WithMessage("Id must be not null");
            RuleFor(x => x.Price).GreaterThan(0.0);
            RuleFor(x => x.OldPrice).GreaterThan(0.0);
            RuleFor(x => x.Discount).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title must be not empty");
            RuleFor(x => x.Domain).NotEmpty().WithMessage("Domain must be not null or empty");
            RuleFor(x => x.URL).NotEmpty().WithMessage("URL must be not null or empty");
        }
    }
}
