using AutoMapper;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.Infrastructure.Models;
using BulbaCourses.Analytics.Models.V1;

namespace BulbaCourses.Analytics.BLL.Ensure.MappingProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            // Db Dto
            CreateMap<ReportDto, ReportDb>();
            CreateMap<ReportDb, ReportDto>();
            // Vm Dto
            CreateMap<ReportDto, Report>();
            CreateMap<ReportDto, ReportNew>();
            CreateMap<ReportNew, ReportDto>();
            CreateMap<ReportDto, ReportShort>();

        }
    }
}
