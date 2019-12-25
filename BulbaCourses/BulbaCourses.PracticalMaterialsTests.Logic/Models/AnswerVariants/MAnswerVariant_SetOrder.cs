using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants
{   
    public class MAnswerVariant_SetOrder
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int SortKey { get; set; }

        public int CorrectOrderKey { get; set; }
    }
}
