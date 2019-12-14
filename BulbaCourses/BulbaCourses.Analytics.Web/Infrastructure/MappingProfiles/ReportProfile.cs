using AutoMapper;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.Web.Models;

namespace BulbaCourses.Analytics.Web.Infrastructure.MappingProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDto, ReportVm>();            
            CreateMap<ReportShortDto, ReportShortVm>();            
        }
    }
}