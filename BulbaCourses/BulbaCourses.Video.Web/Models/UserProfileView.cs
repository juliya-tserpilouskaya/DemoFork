using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    [Validator(typeof(UserProfileViewValidator))]
    public class UserProfileView
    {
        public string Login { get; set; }
        //public string AvatarPath { get; set; }
        public Subscription SubscriptionType { get; set; }
    }
}