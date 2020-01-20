using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BulbaCourses.Web.Data
{
    public class UserContext : IdentityDbContext<IdentityUser>
    {
        public UserContext() : base("UserDbConnection")
        {
            
        }
    }
}