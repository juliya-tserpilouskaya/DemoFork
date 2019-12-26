using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    [Validator(typeof(UserForgotPasswordViewValidator))]
    public class UserForgotPasswordView
    {
        public string Email { get; set; }
    }
}