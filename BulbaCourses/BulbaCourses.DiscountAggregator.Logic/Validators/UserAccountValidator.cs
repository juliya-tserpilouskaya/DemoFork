using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    //public class UserAccountValidator : AbstractValidator<UserAccount>
    //{
    //    public UserAccountValidator(IUserAccountService userAccountService)
    //    {
    //        RuleSet("AddAccount", () =>
    //         {
    //             RuleFor(x => x.Login).NotEmpty().Length(6, 100);
    //             RuleFor(x => x.Password).NotEmpty().Length(7, 32);
    //             RuleFor(x => x.Email).NotEmpty().EmailAddress();
    //             RuleFor(x => x.UserProfile.LastName).NotEmpty().Length(1, 105);
    //             RuleFor(x => x.UserProfile.FirstName).NotEmpty().Length(1, 105);
    //             RuleFor(x => x.UserProfile.DateOfBirth).NotEmpty();
    //             //RuleFor(x => x.UserProfile);

    //             RuleFor(x => x.Login).MustAsync(async (login, token) =>
    //              !(await userAccountService.ExistsAsync(login).ConfigureAwait(false)));
    //         });

    //        RuleSet("UpdateAccount", () =>
    //        {
    //            RuleFor(x => x.Login).NotEmpty().Length(6, 100);
    //            RuleFor(x => x.Password).NotEmpty().Length(7, 32);
    //            RuleFor(x => x.Email).NotEmpty().EmailAddress();
    //            RuleFor(x => x.UserProfile.LastName).NotEmpty().Length(1, 105);
    //            RuleFor(x => x.UserProfile.FirstName).NotEmpty().Length(1, 105);
    //            RuleFor(x => x.UserProfile.DateOfBirth).NotEmpty();
    //            //RuleFor(x => x.UserProfile);

    //            RuleFor(x => x.Login).MustAsync(async (login, token) =>
    //             (await userAccountService.ExistsAsync(login).ConfigureAwait(false)));
    //        });
    //    }
    //}
}
