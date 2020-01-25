using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator(IUserProfileServices userAccountService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("AddProfile", () =>
             {
                 RuleFor(x => x.Email).NotEmpty().EmailAddress();
             });

            RuleSet("UpdateProfile", () =>
            {
                 //   RuleFor(x => x.Id).MustAsync(async (id, token) =>
                 //(await userAccountService.ExistsAsync(id).ConfigureAwait(false)));
            });

            RuleFor(x => x.FirstName).NotEmpty().Length(1, 105);
            RuleFor(x => x.LastName).NotEmpty().Length(1, 105);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Subscription).NotEmpty();
            RuleFor(x => x.SearchCriteria.MinDiscount).GreaterThanOrEqualTo(0).WithMessage("Dicount must be greater or equal than 0");
            RuleFor(x => x.SearchCriteria.MaxDiscount).LessThan(100).GreaterThanOrEqualTo(0).WithMessage("Dicount must be less than 100");
        }
    }
}
