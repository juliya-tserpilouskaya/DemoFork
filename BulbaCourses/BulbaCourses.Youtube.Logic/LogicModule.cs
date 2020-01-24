using BulbaCourses.Youtube.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.Youtube.DataAccess.Repositories;
using Ninject.Extensions.Factory;
using BulbaCourses.Youtube.DataAccess;
using AutoMapper;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using FluentValidation;

namespace BulbaCourses.Youtube.Logic
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
            Bind<IVideoService>().To<VideoService>();
            Bind<IServiceFactory>().ToFactory();

            Bind<IChannelRepository>().To<ChannelRepository>();
            Bind<ISearchRequestsRepository>().To<SearchRequestsRepository>();
            Bind<IStoryRepository>().To<StoryRepository>();
            Bind<IVideoRepository>().To<VideoRepository>();
            Bind<YoutubeContext>().ToSelf().InThreadScope();

            //Binding for IValidators
            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchRequest>()
                .ForEach(result => Bind(result.InterfaceType)
                    .To(result.ValidatorType));


            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SearchStoryDb, SearchStory>().ReverseMap();
                cfg.CreateMap<SearchRequestDb, SearchRequest>().ReverseMap();
                cfg.CreateMap<ResultVideoDb, ResultVideo>().ReverseMap();
                cfg.CreateMap<ChannelDb, Channel>().ReverseMap();
            }));
            Bind<IMapper>().ToConstant(mapper);

        }
    }
}
