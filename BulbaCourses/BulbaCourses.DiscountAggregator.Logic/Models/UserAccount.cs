using BulbaCourses.DiscountAggregator.Logic.Validators;
using FluentValidation.Attributes;
using System;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    //[Validator(typeof(UserAccountValidator))]
    public class UserAccount
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public UserProfile UserProfile { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
