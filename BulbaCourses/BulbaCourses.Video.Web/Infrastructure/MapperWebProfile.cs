using AutoMapper;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Models;
using BulbaCourses.Video.Web.Models.CourseViews;
using BulbaCourses.Video.Web.Models.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Infrastructure
{
    public class MapperWebProfile : Profile
    {
        public MapperWebProfile()
        {
            CreateMap<UserProfileView, UserInfo>();
            CreateMap<UserInfo, UserProfileView>();
            CreateMap<UserRegisterView, UserInfo>();
            CreateMap<UserEditView, UserInfo>();

            CreateMap<CourseView, CourseInfo>();
            CreateMap<CourseInfo, CourseView>();

            CreateMap<CommentView, CommentInfo>();
            CreateMap<CommentInfo, CommentView>();
        }
    }
}