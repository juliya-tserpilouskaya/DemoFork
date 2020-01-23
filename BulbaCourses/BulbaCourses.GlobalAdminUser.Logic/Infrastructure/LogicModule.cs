using BulbaCourses.GlobalAdminUser.Data.Context;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Data.Repositories;
using BulbaCourses.GlobalAdminUser.Logic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();

            Bind<IUserService>().To<UserService>();

            Bind<IRoleService>().To<RoleService>();

            Bind<IUserProfileService>().To<UserProfileService>();

            Bind<IUserAdditonalInfoRepository>().To<UserAdditionalInfoRepository>();

            Bind<UsersContext>().ToSelf().InSingletonScope();
        }
    }
}
