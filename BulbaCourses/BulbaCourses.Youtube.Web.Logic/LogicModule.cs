using BulbaCourses.Youtube.Web.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace BulbaCourses.Youtube.Web.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestService>().To<RequestService>();
        }
    }
}
