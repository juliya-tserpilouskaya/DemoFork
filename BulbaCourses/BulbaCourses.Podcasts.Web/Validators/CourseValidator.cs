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
                RuleFor(x => x.Name).Must(((name) => !(service.Exists(name))));
            });
            RuleSet("UpdateCourse", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Name).Must(((name) => (service.Exists(name))));
            });
            RuleSet("DeleteCourse", () =>
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Name).Must(((name) => (service.Exists(name))));
            });

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
            RuleFor(x => x.Price).GreaterThan(0.0);
        }
    }
}
