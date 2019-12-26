using BulbaCourses.Video.Web.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.UserViews
{
    public class UserProfileView
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Firstname")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public string AvatarPath { get; set; }
        public Subscription SubscriptionType { get; set; }
    }
}