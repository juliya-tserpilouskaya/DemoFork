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

            UserAdditionalInfoDb usersAdditionalInfo = new UserAdditionalInfoDb
            {
                UserProfileId=Guid.NewGuid().ToString(),
                UserId="2b22b89d-3063-4ff1-a444-3831863ba3ae",
                Sex = "male",
                Age = 24,
                City = "Minsk",
            };

            globalAdminDbContext.UsersAdditionalInfo.Add(usersAdditionalInfo);            
            globalAdminDbContext.SaveChanges();
        }
    }
}
