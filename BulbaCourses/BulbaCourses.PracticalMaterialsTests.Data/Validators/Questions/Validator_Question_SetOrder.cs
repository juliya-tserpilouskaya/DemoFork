using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.Questions
{
    public class Validator_Question_SetOrder : AbstractValidator<MQuestion_SetOrderDb>
    {
        public Validator_Question_SetOrder()
        {

        }
    }
}
