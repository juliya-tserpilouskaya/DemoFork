using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models.CourseViews;
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
            //RuleFor(x=>x.Description).
           
            RuleFor(x => x.Price).GreaterThan(0.0);
        }

    }
} 