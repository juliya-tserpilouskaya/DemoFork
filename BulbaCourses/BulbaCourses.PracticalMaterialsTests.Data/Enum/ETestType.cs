using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Enum
{
    public enum ETestType : int
    {
        /// <summary>
        /// Type of test, where user need to find one or more correct answer from list
        /// </summary>
        TestChoosingAnswerFromList = 1,

        /// <summary>
        /// Type of test, where user need to arrange the elements in the correct order
        /// </summary>
        TestSetOrder = 2,

        /// <summary>
        /// Type of test, where user need to set correct elements into question text
        /// </summary>
        TestSetIntoMissingElements = 3
    }
}
