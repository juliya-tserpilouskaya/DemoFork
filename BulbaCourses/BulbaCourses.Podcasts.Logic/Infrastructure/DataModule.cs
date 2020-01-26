using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.Podcasts.Data;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Managers;
using BulbaCourses.Podcasts.Data.Models;
using BulbaComments.Podcasts.Data.Managers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;

namespace BulbaCourses.Podcasts.Logic
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IManager<AudioDb>>().To<AudioManager>();
            Bind<IManager<CourseDb>>().To<CourseManager>();
            Bind<IManager<ContentDb>>().To<ContentManager>();
            Bind<IManager<UserDb>>().To<UserManager>();
            Bind<IManager<CommentDb>>().To<CommentManager>();
            Bind<BinaryFormatter>().ToSelf();
            Bind<BaseManager>().ToSelf();
        }
    }
}
