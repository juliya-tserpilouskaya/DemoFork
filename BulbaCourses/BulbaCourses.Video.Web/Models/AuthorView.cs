using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    [Validator(typeof(AuthorViewValidator))]
    public class AuthorView
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Annotation { get; set; }
        public string Professions { get; set; }
    }
}