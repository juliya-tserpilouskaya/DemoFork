using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation;

namespace BulbaCourses.Analytics.BLL.Ensure.Validators
{
    /// <summary>
    /// Represents a dashboard create validator.
    /// </summary>
    public class DashboardCreateValidator : AbstractValidator<DashboardNew>
    {
        /// <summary>
        /// Validates the dashboard when created.
        /// </summary>
        public DashboardCreateValidator(IDashboardsService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Create", () =>
            {
                RuleFor(x => x.ChartId)
                    .NotEmpty()
                    .Must(id => id > 0)
                    .MustAsync((async (id, token) => (await service.ExistsChartIdAsync(id).ConfigureAwait(false))))
                    .WithMessage(Resources.Resource.NotFoundChartById);

                RuleFor(x => x.ReportId)
                    .NotEmpty()
                    .MaximumLength(128)
                    .Matches(@"^[a-zA-Z0-9-]+$")
                    .MustAsync((async (id, token) => (await service.ExistsReportIdAsync(id).ConfigureAwait(false))))
                    .WithMessage(Resources.Resource.NotFoundReportById);

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
