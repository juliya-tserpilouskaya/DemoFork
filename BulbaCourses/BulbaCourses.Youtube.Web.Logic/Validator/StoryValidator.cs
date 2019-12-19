using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.Logic.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Validator
{
    public class StoryValidator : AbstractValidator<SearchStory>
    {
        public StoryValidator(IStoryService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddStory", () =>
            {
                RuleFor(x => x.Id).Null().WithMessage("Id must be null");
                RuleFor(x => x.SearchRequest).NotNull().WithMessage("Search request must not be null");
                RuleFor(x => x.User).NotNull().WithMessage("User must not be null");
            });
        }
    }
}
