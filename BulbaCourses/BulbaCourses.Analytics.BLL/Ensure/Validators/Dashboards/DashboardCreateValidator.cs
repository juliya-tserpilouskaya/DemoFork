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
        public DashboardCreateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Create", () =>
            {
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
