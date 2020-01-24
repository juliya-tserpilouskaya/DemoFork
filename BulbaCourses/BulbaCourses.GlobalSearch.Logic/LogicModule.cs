using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Services;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Data.Services;
using BulbaCourses.GlobalSearch.Data;

namespace BulbaCourses.GlobalSearch.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILearningCourseService>().To<LearningCourseService>();
            Bind<ISearchQueryService>().To<SearchQueryService>();
            Bind<IBookmarkService>().To<BookmarkService>();
            Bind<IAnonymousUserService>().To<AnonymousUserService>();
            Bind<IRegisteredUserService>().To<RegisteredUserService>();
            Bind<ISearchQueryDbService>().To<SearchQueryDbService>();
            Bind<ICourseDbService>().To<CourseDbService>();
            Bind<ISearchService>().To<SearchService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserDbService>().To<UserDbService>();
            Bind<IBookmarkDbService>().To<BookmarkDbService>();
            Bind<GlobalSearchContext>().ToSelf();
        }
    }
}
