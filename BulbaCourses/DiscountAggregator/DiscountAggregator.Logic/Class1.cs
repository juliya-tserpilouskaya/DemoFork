using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountAggregator.Logic.Services;
using Ninject.Modules;

namespace DiscountAggregator.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseServices>().To<CourseServices>();
        }
    }
}
