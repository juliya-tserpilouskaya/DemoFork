using BulbaCourses.Video.Web.Enums;
using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    [Validator(typeof(UserProfileViewValidator))]
    public class UserProfileView
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string AvatarPath { get; set; }
        public Subscription SubscriptionType { get; set; }
    }
}