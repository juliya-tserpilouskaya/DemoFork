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

            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context))
            {
                PasswordValidator = new MinimumLengthValidator(3)
            };

            manager.Create(NewUser("user@test.com", "8C7362B6-AAD5-42F7-B366-CE45304D03A5"), "123");
            manager.Create(NewUser("admin@test.com", "D4AE2E6E-AA52-4D7E-A1E6-6AB2A101BBFD"), "admin");
        }

        /// <summary>
        /// Creates a new IdentityUser.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IdentityUser NewUser(string email, string id) =>
            new IdentityUser(email)
            {
                Email = email,
                EmailConfirmed = true,
                Id = id
            };
    }
}
