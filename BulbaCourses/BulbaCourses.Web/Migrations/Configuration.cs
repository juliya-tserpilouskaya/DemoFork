using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BulbaCourses.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.Web.Data.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulbaCourses.Web.Data.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Users.Any())
            {
                return;
            }

            var user = new IdentityUser("user@test.com");
            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            manager.PasswordValidator = new MinimumLengthValidator(3);
            manager.Create(user, "123");
        }
    }
}
