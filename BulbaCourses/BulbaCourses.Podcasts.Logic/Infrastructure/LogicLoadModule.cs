using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Infrastructure
{
    public class LogicLoadModule : NinjectModule
    {
        public override void Load()
        {
            //bind services
            Bind<IUserService>().To<UserService>();
            Bind<ICourseService>().To<CourseService>();
            Bind<ICommentService>().To<CommentService>();

        }
    }
}
