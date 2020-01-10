using BulbaCourses.Video.Web.Enums;
using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    public class UserProfileView
    {
        public string Login { get; set; }
        public string Biography { get; set; }
        public string AvatarPath { get; set; }
        //public Subscription SubscriptionType { get; set; }
    }
}