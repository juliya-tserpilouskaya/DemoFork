using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Enum
{
    public enum EUserRole : int
    {
        /// <summary>
        /// Site guest
        /// </summary>
        BaseUser = 1,

        /// <summary>
        /// User, who can create tests 
        /// </summary>
        AuthorTest = 2,

        /// <summary>
        /// Person responsible for managing and maintaining the domains
        /// </summary>
        Administrator = 3
    }
}
