using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Storage
{
    public class LinksStorage: ILinksStorage
    {
        private List<Links> _reports = null;

        public List<Links> Storage
        {
            get
            {
                if (_reports == null)
                {
                    _reports = GetLinks();
                }
                return _reports;
            }
        }

        private static List<Links> GetLinks()
        {        
            List<Links> links = new List<Links>();

            ModifyLinks(ref links, 1, 1, 5);
            ModifyLinks(ref links, 2, 6, 12);
            ModifyLinks(ref links, 3, 13, 15);
            ModifyLinks(ref links, 4, 8, 14);
            ModifyLinks(ref links, 5, 0, 1);

            return links;
        }

        private static void ModifyLinks(ref List<Links> links, int reportId, int beginDashboardId, int endDashboardId)
        {
            for (int i = beginDashboardId; i < endDashboardId; i++)
            {
                Links ls = new Links() { Id = Guid.NewGuid().ToString(), ReportId = reportId.ToString(), DashboardId = i.ToString() };
                links.Add(ls);
            }
        }
    }
}
