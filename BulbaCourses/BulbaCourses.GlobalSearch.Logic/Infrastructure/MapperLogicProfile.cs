using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Infrastructure
{
    class MapperLogicProfile : Profile
    {
        public MapperLogicProfile()
        {
            CreateMap<CourseDB, LearningCourseDTO>().ReverseMap();
            CreateMap<CourseItemDB, LearningCourseItemDTO>().ReverseMap();
            CreateMap<SearchQueryDB, SearchQueryDTO>().ReverseMap();
            CreateMap<BookmarkDB, BookmarkDTO>().ReverseMap();
            CreateMap<UserDB, UserDTO>().ReverseMap();
        }
    }
}
