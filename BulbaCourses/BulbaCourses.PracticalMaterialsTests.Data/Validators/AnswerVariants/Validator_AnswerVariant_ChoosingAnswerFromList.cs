using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.AnswerVariants
{
    public class Validator_AnswerVariant_ChoosingAnswerFromList : AbstractValidator<MAnswerVariant_ChoosingAnswerFromListDb>
    {
        public Validator_AnswerVariant_ChoosingAnswerFromList()
        {

        }
    }
}
