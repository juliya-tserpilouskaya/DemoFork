using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BulbaCourses.Web.Migrations
{
    using Bogus;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

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
            FakeUser(manager).Wait();
            //manager.AddClaimAsync()
            //await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, model.FirstName));
            //await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, model.LastName));
        }
        /// <summary>
        /// Create fake users
        /// </summary>
        /// <param name="manager"></param>
        private async Task FakeUser(UserManager<IdentityUser> _userManager)
        {
            var faker = new Bogus.Faker();
            for (int i = 0; i < 10; i++)
            {
                string givenName = faker.Person.FirstName;
                string lastName = faker.Person.LastName;
                string email = faker.Internet.Email(givenName);
                string address = faker.Address.FullAddress();
                DateTime birthDate = faker.Person.DateOfBirth;
                string gender = faker.Person.Gender.ToString();

                var user = new IdentityUser(email)
                {
                    Email = email,
                    EmailConfirmed = true //remove for production
                };

                //sample code
                var result = await _userManager.CreateAsync(user, "12345");
                if (!result.Succeeded) return;


                await _userManager.AddClaimAsync(user.Id, new System.Security.Claims.Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, givenName));
                await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, lastName));
                await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.Email, user.Email));
                await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.Address, address));
                await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.BirthDate, birthDate.ToString()));
                await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.Gender, gender));

            }
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
