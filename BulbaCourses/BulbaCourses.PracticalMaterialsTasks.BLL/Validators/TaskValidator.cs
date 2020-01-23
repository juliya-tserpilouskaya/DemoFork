using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Validators
{
    public class TaskValidator: AbstractValidator<TaskDTO>
    {
        public TaskValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("addTask", () =>
            {
                // TODO add DTO without ID field
                RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x)).WithMessage("Id must be null or empty");
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is not null or empty");
                RuleFor(x => x.Text).NotNull().NotEmpty().MinimumLength(5).WithMessage("Task text is not null or empty");
                RuleFor(x => x.TaskLevel).NotNull().NotEmpty().WithMessage("TaskLevel text is not null or empty");
                RuleFor(x => x.Created).NotNull().NotEmpty().WithMessage("DateCreated is not null or empty");
            });
            RuleFor(x => x.Id).Must(x => string.IsNullOrEmpty(x));//.WithMessage("Id must be null or empty");
            RuleFor(x => x.Name).NotNull().NotEmpty();//.WithMessage("Name is not null or empty");
            RuleFor(x => x.Text).NotNull().NotEmpty().MinimumLength(5).WithMessage("Task text is not null or empty");
            RuleFor(x => x.TaskLevel).NotNull().NotEmpty().WithMessage("TaskLevel text is not null or empty");
            RuleFor(x => x.Created).NotNull().NotEmpty().WithMessage("DateCreated is not null or empty");
          



        }
       
    }
}
