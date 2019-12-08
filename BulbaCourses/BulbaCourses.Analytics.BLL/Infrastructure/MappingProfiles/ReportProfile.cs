using AutoMapper;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.DAL.Models;

namespace BulbaCourses.Analytics.BLL.Infrastructure.MappingProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDb, ReportDto>();
        }
    }
}
