using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Validators
{
    public class VideoViewValidator : AbstractValidator<VideoView>
    {
        public VideoViewValidator(IVideoService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("AddVideo", () => {
                RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(32).WithMessage("Video name is required.");
                RuleFor(c => c.Url).NotEmpty().WithMessage("Video url is required.");
                RuleFor(c => c.Order).GreaterThan(0).WithMessage("Video order must be greater than 0.");

            });

            RuleSet("UpdateVideo", () => {
                RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(32).WithMessage("Video name is required.");
                RuleFor(c => c.Url).NotEmpty().WithMessage("Video url is required.");
                RuleFor(c => c.Order).GreaterThan(0).WithMessage("Video order must be greater than 0.");
            });
        }
    }
}