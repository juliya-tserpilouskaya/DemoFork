using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.Models;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class SearchQueryValidator : AbstractValidator<SearchQueryDTO>
    {
        public SearchQueryValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            RuleFor(x => x.Query).NotEmpty().WithMessage("Search Query must not be empty or null");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date must not be empty or null");
        }
    }
}
