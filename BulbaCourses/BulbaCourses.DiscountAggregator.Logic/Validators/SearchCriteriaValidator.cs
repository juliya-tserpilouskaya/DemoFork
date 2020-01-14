using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class SearchCriteriaValidator : AbstractValidator<SearchCriteria>
    {
        public SearchCriteriaValidator(ISearchCriteriaServices searchCriteriaServices)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("AddCriteria", () =>
            {
                //RuleFor(x => x.).NotEmpty();
            });

            RuleSet("UpdateCriteria", () =>
            {
                //   RuleFor(x => x.Id).MustAsync(async (id, token) =>
                //(await searchCriteriaServices.ExistsAsync(id).ConfigureAwait(false)));
            });

        }
    }
}
