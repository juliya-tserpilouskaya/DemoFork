using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.BLL.Services
{
    /// <summary>
    /// Represents database creation methods.
    /// </summary>
    public static class Seed
    {
        /// <summary>
        /// Seeds analytics database.
        /// </summary>
        /// <param name="repository"></param>
        public static void SeedDatabase(IRepository<ReportDb> repository)
        {
            var report = new ReportDb()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Основной отчет",
                Description = "Описание основного отчета",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Creator = "Создатель отчета",
                Modifier = "Модификатор отчета",
                Dashboards = new List<DashboardDb>() {
                    new DashboardDb()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ChartId = 1,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Creator = "Создатель дашборда",
                        Modifier = "Модификатор дашборда",
                        Name = "Дашборд 1"
                    }
                }
            };
            repository.CreateAsync(report);
        }
    }
}
