using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.Logic.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Logic.Validator
{
    public class StoryValidator : AbstractValidator<SearchStory>
    {
        public StoryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddStory", () =>
            {
                RuleFor(x => x.Id).Null().WithMessage("Id must be null");
                RuleFor(x => x.SearchRequest_Id).NotNull().WithMessage("Search requestId must not be null");
                RuleFor(x => x.UserId).NotNull().WithMessage("UserId must not be null");
            });
        }
    }
}
