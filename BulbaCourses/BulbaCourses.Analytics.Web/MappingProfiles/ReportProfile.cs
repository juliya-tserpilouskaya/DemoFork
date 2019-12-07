using AutoMapper;
using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using BulbaCourses.Analytics.Web.Models;

namespace BulbaCourses.Analytics.Web.MappingProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<IReportDto, ReportVm>();
            CreateMap<IReportDb, IReportDto>();
        }
    }
}