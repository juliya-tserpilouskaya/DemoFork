using AutoMapper;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Infrastructure
{
    public class MapperLogicProfile : Profile
    {
        public MapperLogicProfile()
        {
            CreateMap<UserDb, UserLogic>().ReverseMap();

            CreateMap<CommentDb, CommentLogic>().ReverseMap();

            CreateMap<CourseDb, CourseLogic>().ReverseMap();

            CreateMap<ContentDb, ContentLogic>().ReverseMap();

            CreateMap<AudioDb, AudioLogic>().ReverseMap();

        }
    }
}
