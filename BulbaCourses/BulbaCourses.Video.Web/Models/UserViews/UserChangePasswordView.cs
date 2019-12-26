using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    [Validator(typeof(UserChangePasswordViewValidator))]
    public class UserChangePasswordView
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}