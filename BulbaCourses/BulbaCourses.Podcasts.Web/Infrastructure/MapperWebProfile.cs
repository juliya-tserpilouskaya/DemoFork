using AutoMapper;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Web.Infrastructure
{
    public class MapperWebProfile : Profile
    {
        public MapperWebProfile()
        {
            CreateMap<UserWeb, UserLogic>().ReverseMap();

            CreateMap<CourseWeb, CourseLogic>().ReverseMap();

            CreateMap<CommentWeb, CommentLogic>().ReverseMap();

            CreateMap<AudioWeb, AudioLogic>().ReverseMap();

            CreateMap<ContentWeb, ContentLogic>().ReverseMap();
        }
    }
}