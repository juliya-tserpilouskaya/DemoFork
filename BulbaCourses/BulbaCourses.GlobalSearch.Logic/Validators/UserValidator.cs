using BulbaCourses.GlobalSearch.Logic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            //RuleFor(u => u.Id).NotEmpty().WithMessage("User must have id");
            //RuleFor(u => u.Authorization)
        }
    }
}
