namespace BulbaCourses.Youtube.DataAccess.Migrations
{
    using BulbaCourses.Youtube.DataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.Youtube.DataAccess.YoutubeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulbaCourses.Youtube.DataAccess.YoutubeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Seed Database for IdentityDbContext
            //    var userManager = new UserManager<IdentityUser>(
            //        new UserStore<IdentityUser>(context));
            //    userManager.Create(new IdentityUser("Vano"),"Vanopass");
            //    userManager.Create(new IdentityUser("Balu"), "Balupass");
            //    userManager.Create(new IdentityUser("Homa"), "Homapass");
            //    userManager.Create(new IdentityUser("Nata"), "Natapass");
            //    userManager.Create(new IdentityUser("Kuba"), "Kubapass");
            //    userManager.Create(new IdentityUser("Dona"), "Donapass");
            //    userManager.Create(new IdentityUser("Boris"), "Borispass");
            //    userManager.Create(new IdentityUser("Kesha"), "Keshapass");
            //    userManager.Create(new IdentityUser("admin"), "admin");
            //    context.SaveChanges();
        }
    }
}
