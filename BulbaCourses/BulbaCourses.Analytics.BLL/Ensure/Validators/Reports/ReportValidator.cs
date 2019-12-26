using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Ensure.Validators.Reports
{
    /// <summary>
    /// Represents a report validator.
    /// </summary>
    public class ReportValidator : AbstractValidator<Report>
    {
        /// <summary>
        /// Validates the report when updated.
        /// </summary>
        public ReportValidator(IReportsService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Update", () =>
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .MaximumLength(128)
                    .Matches(@"^[a-zA-Z0-9-]+$")
                    .MustAsync((async (id, token) => (await service.ExistsIdAsync(id).ConfigureAwait(false))))
                    .WithMessage(Resources.Resource.NotFoundReport);

                RuleFor(x => x.Name)
                    .Transform(n => n.SpaceFix())
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(128)
                    .Matches(@"^[а-яА-ЯёЁa-zA-Z0-9.,:;&$%()-+ ]+$");

                RuleFor(x => x.Description)
                    .Transform(d => d.SpaceFix())
                    .MaximumLength(255)
                    .Matches(@"(^[а-яА-ЯёЁa-zA-Z0-9.,:;&$%()-+ ]+$)|(^\s*$)");
            });
        }
    }
}
