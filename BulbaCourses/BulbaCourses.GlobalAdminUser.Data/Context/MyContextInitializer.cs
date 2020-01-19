using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Data.Entity;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    class MyContextInitializer : CreateDatabaseIfNotExists<GlobalAdminDbContext>
    {
        protected override void Seed(GlobalAdminDbContext globalAdminDbContext)
        {
            #region comment addUser
            //UserDb user1 = new UserDb
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Username = "Lapatelli",
            //    Password = "Maks",
            //    Email = "maksim.m.yudin@mail.ru",
            //    //TelephoneNumber = "+375297837978"
            //};
            #endregion

            UserProfileDb userprofile = new UserProfileDb
            {
                UserProfileId=Guid.NewGuid().ToString(),
                Sex = "male",
                Age = 24,
                City = "Minsk",
            };

            globalAdminDbContext.UserProfiles.Add(userprofile);            
            globalAdminDbContext.SaveChanges();
        }
    }
}
