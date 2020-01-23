using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BulbaCourses.Web.Security
{

    public class BulbaUserManager : UserManager<IdentityUser, string>
    {
        public BulbaUserManager(IUserStore<IdentityUser, string> store) : base(store)
        {
            this.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
                RequiredLength = 3
            };

            this.UserValidator = new UserValidator<IdentityUser>(this)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false
            };
        }
    }
}