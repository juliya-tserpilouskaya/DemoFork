using AutoMapper;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.Infrastructure.Models;
using BulbaCourses.Analytics.Models.V1;

namespace BulbaCourses.Analytics.BLL.Ensure.MappingProfiles
{
    /// <summary>
    /// Represents dashboard profile.
    /// </summary>
    public class DashboardProfile : Profile
    {
        /// <summary>
        /// Creates dashboard profile.
        /// </summary>
        public DashboardProfile()
        {
            // Db Dto
            CreateMap<DashboardDto, DashboardDb>();
            CreateMap<DashboardDb, DashboardDto>();
            
            // Vm Dto
            CreateMap<DashboardDto, DashboardShort>();
            CreateMap<DashboardShort, DashboardDto>();

            CreateMap<DashboardDto, DashboardNew>();
            CreateMap<DashboardNew, DashboardDto>();
        }
    }
}
