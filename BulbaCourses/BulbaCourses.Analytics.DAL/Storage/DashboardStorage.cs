using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using BulbaCourses.Analytics.DAL.Interfaces;

namespace BulbaCourses.Analytics.DAL.Storage
{  

    public class DashboardStorage : IDashboardStorage
    {
        private List<Dashboard> _dashboards = null;

        public List<Dashboard> Storage
        {
            get
            {
                if (_dashboards == null)
                {
                    _dashboards = GetDashboards();
                }
                return _dashboards;
            }
        }

        private static List<Dashboard> GetDashboards()
        {
            var generator = new Faker<Dashboard>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => "Analysis of " + _.Commerce.Product());

            int count = 15;
            var dashboards = generator.Generate(count);

            int number = 1;
            foreach (var dashboard in dashboards)
            {
                dashboard.Id = number.ToString();
                number++;
            }

            return dashboards;
        }
    }
}
