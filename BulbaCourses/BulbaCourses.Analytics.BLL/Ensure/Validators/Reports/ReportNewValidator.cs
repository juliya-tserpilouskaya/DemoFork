using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation;

namespace BulbaCourses.Analytics.BLL.Ensure.Validators
{
    public class ReportNewValidator : AbstractValidator<ReportNew>
    {
        public ReportNewValidator(IReportsService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddReport", () =>
            {
                RuleFor(x => x.Name)
                    .Transform(n => n.SpaceFix())
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(10)
                    .Matches("^[а-яА-ЯёЁa-zA-Z0-9. ]+$")
                    .MustAsync((async (name, token) => !(await service.ExistsAsync(name)
                    .ConfigureAwait(false))))
                    .WithMessage(Resources.Resource.ReportExists);
            });
        }
    }
}
