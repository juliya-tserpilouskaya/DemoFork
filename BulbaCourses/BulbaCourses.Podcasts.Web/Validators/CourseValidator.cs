using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Validators;

namespace BulbaCourses.Podcasts.Web.Validators
{
    class CourseValidator : AbstractValidator<CourseWeb>
    {
        public CourseValidator(ICourseService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            RuleSet("AddCourse", () =>
            {
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));

                RuleFor(c => c.Name).MustAsync((async (title, token) => !(await service.ExistsAsync(title)))).WithMessage("Name already taken.");
                RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(32).WithMessage("Course name is required.");
                RuleFor(c => c.Price).GreaterThan(0).WithMessage("Course price must be greater than 0.");

                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsAsync(title)))).WithMessage("Course already exists.");
            });
            RuleSet("UpdateCourse", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(c => c.Price).GreaterThan(0).WithMessage("Course price must be greater than 0.");

                RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsAsync(title)))).WithMessage("Course not exists.");
            });
            RuleSet("DeleteCourse", () =>
            {
                RuleFor(x => x.Id).NotEmpty();

            RuleFor(c => c.Id).MustAsync((async (title, token) => !(await service.ExistsAsync(title)))).WithMessage("Course not exists.");
            });
        }
    }
}
