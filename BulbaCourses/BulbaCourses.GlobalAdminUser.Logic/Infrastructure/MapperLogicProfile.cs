using AutoMapper;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic
{
    public class MapperLogicProfile:Profile
    {
        public MapperLogicProfile()
        {
            CreateMap<UserDb, UserDTO>();
            CreateMap<UserDTO, UserDb>();
        }
    }
}
