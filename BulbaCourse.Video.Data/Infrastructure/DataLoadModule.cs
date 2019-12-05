using BulbaCourse.Video.Data.Interfaces;
using BulbaCourse.Video.Data.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Data.Infrastructure
{
    public class DataLoadModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<ICourseRepository>().To<CourseRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
        }
    }
}
