using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic
{
    public class AutoMapperLogicProfile :  Profile
    {
        public AutoMapperLogicProfile()
        {
            CreateMap<CourseDb, Course>().ReverseMap();
            CreateMap<UserProfileDb, UserProfile>().ReverseMap();
            CreateMap<CourseBookmarkDb, CourseBookmark>().ReverseMap();
            CreateMap<CourseCategoryDb, CourseCategory>().ReverseMap();
            CreateMap<DomainDb, Domain>().ReverseMap();
            CreateMap<SearchCriteriaDb, SearchCriteria>().ReverseMap();
            CreateMap<CourseDb,CoursesITAcademy>().ReverseMap();
        }
    }
}
