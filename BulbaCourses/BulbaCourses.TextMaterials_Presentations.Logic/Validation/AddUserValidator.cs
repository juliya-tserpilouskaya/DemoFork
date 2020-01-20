using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic;
using Presentations.Logic.Services;

namespace BulbaCourses.TextMaterials_Presentations.Logic.Validation
{
    class AddUserValidator : AbstractValidator<User>
    {
        public AddUserValidator(ITeacherService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
        }

        public AddUserValidator(IStudentService service)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.Id).Must(id => !string.IsNullOrEmpty(id)).WithMessage("Id must not be Empty or null");
        }
    }
}
