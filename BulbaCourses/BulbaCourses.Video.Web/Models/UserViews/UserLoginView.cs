using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    [Validator(typeof(UserLoginViewValidator))]
    public class UserLoginView
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}