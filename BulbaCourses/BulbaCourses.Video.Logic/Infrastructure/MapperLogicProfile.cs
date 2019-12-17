using AutoMapper;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Infrastructure
{
    public class MapperLogicProfile : Profile
    {
        public MapperLogicProfile()
        {
            CreateMap<UserDb, UserInfo>();
            CreateMap<UserInfo, UserDb>();

            CreateMap<CommentDb, CommentInfo>();
            CreateMap<CommentInfo, CommentDb>();

            CreateMap<CourseDb, CourseInfo>();
            CreateMap<CourseInfo, CourseDb>();
        }
    }
}
