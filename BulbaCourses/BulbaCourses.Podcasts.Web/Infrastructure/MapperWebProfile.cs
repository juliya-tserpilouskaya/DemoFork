using AutoMapper;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using BulbaCourses.Video.Web.Models;
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
            CreateMap<UserWeb, UserLogic>();
            CreateMap<UserLogic, UserWeb>();

            CreateMap<CourseWeb, CourseLogic>();
            CreateMap<CourseLogic, CourseWeb>();

            CreateMap<CommentWeb, CommentLogic>();
            CreateMap<CommentLogic, CommentWeb>();

            CreateMap<AudioWeb, AudioLogic>();
            CreateMap<AudioLogic, AudioWeb>();
        }
    }
}