using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    [Validator(typeof(CommentViewValidator))]
    public class CommentView
    {
        public string Text { get; set; }
    }
}