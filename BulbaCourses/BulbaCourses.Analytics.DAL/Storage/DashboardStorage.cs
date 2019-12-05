using Bogus;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.DAL.Storage
{

    public class DashboardStorage : IDashboardStorage
    {
        private List<IDashboardDb> _dashboards = null;

        public List<IDashboardDb> Storage
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

        private static List<IDashboardDb> GetDashboards()
        {
            var generator = new Faker<IDashboardDb>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => "Analysis of " + _.Commerce.Product());

            int count = 15;
            var dashboards = generator.Generate(count);

            List<IDashboardDb> ireports = new List<IDashboardDb>();

            int number = 1;
            foreach (var dashboard in dashboards)
            {
                dashboard.Id = number.ToString();
                ireports.Add(dashboard);
                number++;
            }

            return dashboards;
        }
    }
}
