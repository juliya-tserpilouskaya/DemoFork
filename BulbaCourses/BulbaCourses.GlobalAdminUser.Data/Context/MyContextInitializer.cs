using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Data.Entity;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    class MyContextInitializer : CreateDatabaseIfNotExists<GlobalAdminDbContext>
    {
        protected override void Seed(GlobalAdminDbContext globalAdminDbContext)
        {
            UserDb user1 = new UserDb
            {
                Id = Guid.NewGuid().ToString(),
                Username = "Lapatelli",
                Password = "Maks",
                Email = "maksim.m.yudin@mail.ru",
                //TelephoneNumber = "+375297837978"
            };

            UserDb user2 = new UserDb
            {
                Id = Guid.NewGuid().ToString(),
                Username = "Anggod",
                Password = "Igor",
                Email = "igor.m.yudin@mail.ru",
                //TelephoneNumber = "+375298683270"
            };

            globalAdminDbContext.Users.Add(user1);
            globalAdminDbContext.Users.Add(user2);
            globalAdminDbContext.SaveChanges();
        }
    }
}
