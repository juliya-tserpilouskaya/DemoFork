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
            CreateMap<UserDb, UserLogic>();
            CreateMap<UserLogic, UserDb>();

            CreateMap<CommentDb, CommentLogic>();
            CreateMap<CommentLogic, CommentDb>();

            CreateMap<CourseDb, CourseLogic>();
            CreateMap<CourseLogic, CourseDb>();
        }
    }
}
