using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    [Validator(typeof(CourseViewInputValidator))]
    public class CourseViewInput
    {
        public string Name { get; set; }
        public CourseLevel Level { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}