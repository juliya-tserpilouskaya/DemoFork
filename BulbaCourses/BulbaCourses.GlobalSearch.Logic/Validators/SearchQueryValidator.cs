using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class SearchQueryValidator : AbstractValidator<SearchQueryDTO>
    {
        public SearchQueryValidator(ISearchQueryService service)
        {
            RuleFor(x => x.Id).Null().WithMessage("Id must be empty or null");
            RuleFor(x => x.Query).NotEmpty().WithMessage("Search Query must not be empty or null");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date must not be empty or null");
            //RuleFor(x => x.Id).MustAsync((async
            //    (id, token) => !(await service.AnyAsync
            //    (id).ConfigureAwait(false))));
        }
    }
}
