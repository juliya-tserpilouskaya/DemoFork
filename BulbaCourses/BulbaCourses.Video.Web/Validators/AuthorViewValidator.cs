using BulbaCourses.Video.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class AuthorViewValidator : AbstractValidator<AuthorView>
    {
        public AuthorViewValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c.Name).NotEmpty().WithMessage("Author name is required.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Name must contain minimum 3 characters.");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Name must contain maximum 20 characters.");

            RuleFor(c => c.Lastname).NotEmpty().WithMessage("Author Lastname is required.");
            RuleFor(c => c.Lastname).MinimumLength(3).WithMessage("Lastname must contain minimum 3 characters.");
            RuleFor(c => c.Lastname).MaximumLength(20).WithMessage("Lastname must contain maximum 20 characters.");

            RuleFor(c => c.Annotation).NotEmpty().WithMessage("Author Annotation is required.");
            RuleFor(c => c.Annotation).MinimumLength(5).WithMessage("Annotation must contain minimum 5 characters.");
            RuleFor(c => c.Annotation).MaximumLength(1000).WithMessage("Annotation must contain maximum 1000 characters.");

            RuleFor(c => c.Professions).NotEmpty().WithMessage("Author Professions is required.");
            RuleFor(c => c.Professions).MinimumLength(3).WithMessage("Professions must contain minimum 3 characters.");
            RuleFor(c => c.Professions).MaximumLength(100).WithMessage("Professions must contain maximum 100 characters.");
        }
    }
}