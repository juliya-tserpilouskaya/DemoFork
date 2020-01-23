using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Ensure.Validators.Dashboards
{
    /// <summary>
    /// Represents a dashboard validator.
    /// </summary>
    public class DashboardValidator : AbstractValidator<DashboardShort>
    {
        /// <summary>
        /// Validates the dashboard when updated.
        /// </summary>
        public DashboardValidator(IDashboardsService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Update", () =>
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .MaximumLength(128)
                    .Matches(@"^[a-zA-Z0-9-]+$")
                    .MustAsync((async (id, token) => (await service.ExistsIdAsync(id).ConfigureAwait(false))))
                    .WithMessage(Resources.Resource.NotFoundDashboard);

                RuleFor(x => x.Name)
                    .Transform(n => n.SpaceFix())
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(128)
                    .Matches(@"^[а-яА-ЯёЁa-zA-Z0-9.,:;&$%()-+ ]+$");
            });
        }
    }
}
