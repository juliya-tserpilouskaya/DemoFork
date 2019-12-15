using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.User
{
    public class ProfileView
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Firstname")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        
        public string AvatarPath { get; set; }
        
        public int SubscriptionType { get; set; }
    }
}