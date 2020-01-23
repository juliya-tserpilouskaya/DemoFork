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
            CreateMap<UserDb, UserDTO>()
                .ForMember(x => x.Lockout, opt => opt.MapFrom(y => BoolToText(y.LockoutEnabled)))
                .ForMember(x=>x.Username, opt=>opt.MapFrom(y=>y.UserName));
            CreateMap<UserDTO, UserDb>();
            CreateMap<RoleDb, RoleDTO>().ReverseMap();
            CreateMap<UserAdditionalInfoDb, UserAdditionalInfoDTO>().ReverseMap();
            CreateMap<UserChangePassword, UserChangePasswordDTO>().ReverseMap();

            CreateMap<UserDTO, UserProfileDTO>();
            CreateMap<UserAdditionalInfoDTO, UserProfileDTO>()
                .ForMember(d => d.Sex, opt => opt.MapFrom(s => s.Sex))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.ProfilePictureUrl, opt => opt.MapFrom(s => s.ProfilePictureUrl));
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Item1.Id))
                //.ForMember(d => d.Username, opt => opt.MapFrom(s => s.Item1.Username))
                //.ForMember(d => d.Password, opt => opt.MapFrom(s => s.Item1.Password))
                //.ForMember(d => d.Email, opt => opt.MapFrom(s => s.Item1.Email))
                //.ForMember(d => d.TelephoneNumber, opt => opt.MapFrom(s => s.Item1.TelephoneNumber));
        }

        private string BoolToText(bool y)
        {
            return y ? "Yes" : "No";
        }
    }


}
