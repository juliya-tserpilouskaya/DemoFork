using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class CourseViewInputValidator : AbstractValidator<CourseViewInput>
    {
        public CourseViewInputValidator(ICourseService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            //RuleSet("AddCourse", () =>
            //{
            //    //RuleFor(x => x.Name). Must(x => !string.IsNullOrEmpty(x)).WithMessage("Name must not be empty or null");
            //    RuleFor(x => x.).MustAsync((async (title, token) => !(await service.ExistsAsync(title).ConfigureAwait(false))));
            //});
            //RuleSet("UpdateCourse", () =>
            //{
            //    RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be empty or null");
            //    RuleFor(x => x.Title).MustAsync((async (title, token) => (await service.ExistsAsync(title).ConfigureAwait(false))));
            //});

            //  RuleFor(x => x.Title).NotEmpty().MaximumLength(20).MinimumLength(5);
            RuleFor(x => x.Price).GreaterThan(0.0);
        }


    }
}