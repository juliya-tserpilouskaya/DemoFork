using BulbaCourses.Video.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class CommentViewValidator : AbstractValidator<CommentView>
    {
        public CommentViewValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c.Text).NotEmpty().WithMessage("Comment text is required.");
        }
    }
}