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
            CreateMap<UserDb, UserInfo>().ReverseMap();
            CreateMap<CommentDb, CommentInfo>().ReverseMap();
            CreateMap<CourseDb, CourseInfo>().ReverseMap();
            CreateMap<TagDb, TagInfo>().ReverseMap();
            CreateMap<VideoMaterialDb, VideoMaterialInfo>().ReverseMap();
            CreateMap<AuthorDb, AuthorInfo>().ReverseMap();
        }
    }
}
