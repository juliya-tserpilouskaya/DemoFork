using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Services;

namespace BulbaCourses.GlobalSearch.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILearningCourseService>().To<LearningCourseService>();
            Bind<ISearchQueryService>().To<SearchQueryService>();
        }
    }
}
