using BulbaCourses.Podcasts.Logic.Services;
using BulbaCourses.Podcasts.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.Podcasts.Data;

namespace BulbaCourses.Podcasts.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ICourseService>().To<CourseService>();
            Bind<ICommentService>().To<CommentService>();
        }
    }
}
