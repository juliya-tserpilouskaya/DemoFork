namespace BulbaCourses.Podcasts.Data.Migrations
{
    using BulbaCourses.Podcasts.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ninject;
    using BulbaCourses.Podcasts.Data.Managers;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.Podcasts.Data.PodcastsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulbaCourses.Podcasts.Data.PodcastsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            var user1 = new UserDb()
            {
                Id = "8C7362B6-AAD5-42F7-B366-CE45304D03A5",
                IsAdmin = true,
                Name = "user@test.com",
                Avatar = null,
                BoughtCourses = null,
                UploadedCourses = null,
                Comments = null,
                Description = "",
                RegistrationDate = DateTime.Now,
                Email = "",
            };

            context.Users.Add(user1);
            base.Seed(context);
        }
    }
}
