using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.Web.Data;
using BulbaCourses.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Modules;

namespace BulbaCourses.Web
{
    public class InjectModule : NinjectModule
    {
        public override void Load()
        {
            //register all needed here
            Bind<UserContext>().ToSelf();
            Bind<IUserStore<IdentityUser,string>>().ToMethod(context => new UserStore<IdentityUser>(context.Kernel.Get<UserContext>()));
            Bind<BulbaUserManager>().ToSelf();
        }
    }
}