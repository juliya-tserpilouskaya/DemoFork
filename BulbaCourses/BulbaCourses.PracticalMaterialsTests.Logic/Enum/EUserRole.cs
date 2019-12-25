using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Enum
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
