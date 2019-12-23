using BulbaCourses.Youtube.Web.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using Ninject.Extensions.Factory;
using BulbaCourses.Youtube.Web.DataAccess;

namespace BulbaCourses.Youtube.Web.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICacheService>().To<CacheService>();
            Bind<IChannelService>().To<ChannelService>();
            Bind<ILogicService>().To<LogicService>();
            Bind<ISearchRequestService>().To<SearchRequestService>();
            Bind<IStoryService>().To<StoryService>();
            Bind<IUserService>().To<UserService>();
            Bind<IVideoService>().To<VideoService>();
            Bind<IServiceFactory>().ToFactory();

            Bind<IChannelRepository>().To<ChannelRepository>();
            Bind<ISearchRequestsRepository>().To<SearchRequestsRepository>();
            Bind<IStoryRepository>().To<StoryRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IVideoRepository>().To<VideoRepository>();
            Bind<YoutubeContext>().ToSelf().InSingletonScope();
        }
    }
}
