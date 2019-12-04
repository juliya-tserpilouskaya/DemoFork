using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Services
{
    internal partial class DashboardService : IDashboardService
    {
        private readonly string _reportId="1";
        private IDataBase _context;

        //public DashboardService(/*string reportId*/)
        //{
        //    _reportId = "1";//reportId;
        //}

        public DashboardDTO ChangeReport(DashboardDTO dashboardDTO)
        {
            throw new NotImplementedException();
        }

        public void Checked(object obj)
        {
            throw new NotImplementedException();
        }

        public DashboardDTO CreateDashboard(DashboardDTO dashboardDTO)
        {
            throw new NotImplementedException();
        }
        
        public DashboardDTO GetDashboardById(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DashboardDTO> GetDashboards()
        {
            throw new NotImplementedException();
        }

        public string RemoveAllDashboards()
        {
            throw new NotImplementedException();
        }

        public string RemoveDashboard(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
