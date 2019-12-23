using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation;

namespace BulbaCourses.Analytics.BLL.Ensure.Validators
{
    /// <summary>
    /// Represents a report create validator.
    /// </summary>
    public class ReportCreateValidator : AbstractValidator<ReportNew>
    {
        /// <summary>
        /// Validates the report when created.
        /// </summary>
        public ReportCreateValidator()
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

                RuleFor(x => x.Description)
                    .Transform(d => d.SpaceFix())
                    .MaximumLength(255)
                    .Matches(@"(^[а-яА-ЯёЁa-zA-Z0-9.,:;&$%()-+ ]+$)|(^\s*$)");
            });
        }
    }
}
