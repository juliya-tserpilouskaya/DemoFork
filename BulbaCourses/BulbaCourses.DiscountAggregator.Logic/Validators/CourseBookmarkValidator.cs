using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class CourseBookmarkValidator : AbstractValidator<CourseBookmark>
    {
        public CourseBookmarkValidator(ICourseBookmarkServices courseBookmarkService)
        {
            RuleSet("AddBookmark", () =>
            {
            });

            RuleFor(x => x.UserProfile).NotEmpty();
            RuleFor(x => x.Course).NotEmpty();
        }
    }
}
