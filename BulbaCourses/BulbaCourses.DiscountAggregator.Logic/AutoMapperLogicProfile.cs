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
            CreateMap<CourseDb, Course>();
            CreateMap<Course, CourseDb>();

            CreateMap<UserAccountDb, UserAccount>();
            CreateMap<UserAccount, UserAccountDb>();
        }
    }
}
