using BulbaCourses.DiscountAggregator.Logic.Models;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class CategoryValidator : AbstractValidator<CourseCategory>
    {
        public CategoryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            //RuleSet("AddCategory", () =>
            //{
            //    RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x)).WithMessage("Id must be null or empty");
            //});

            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).WithMessage("Category name must be not empty or null");
            RuleFor(x => x.Title).NotEmpty().NotNull().MinimumLength(2).WithMessage("Category title must be not empty or null");

   
        }
    }
}
