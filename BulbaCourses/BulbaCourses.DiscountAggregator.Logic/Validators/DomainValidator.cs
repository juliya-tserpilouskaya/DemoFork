using BulbaCourses.DiscountAggregator.Logic.Models;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulbaCourses.DiscountAggregator.Logic.Validators
{
    public class DomainValidator : AbstractValidator<Domain>
    {
        public DomainValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            //RuleSet("AddDomain", () =>
            //{
            //    // TODO add DTO without ID field
            //    RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x)).WithMessage("Id must be null or empty");
            //});

            //RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x)).WithMessage("Id must be null or empty");
            RuleFor(x => x.DomainName).NotEmpty().NotNull().MinimumLength(5).WithMessage("Domain name must be not empty or null");
            RuleFor(x => x.DomainURL).NotEmpty().NotNull().MinimumLength(5).WithMessage("Domain URL must be not empty or null");
        }
    }
}
