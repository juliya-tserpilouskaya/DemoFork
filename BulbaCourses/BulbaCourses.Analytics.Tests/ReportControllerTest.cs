using System.Collections.Generic;
using Bogus;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using FluentAssertions;
using BulbaCourses.Analytics.Web.Models;
using System.Linq;
using AutoMapper;

namespace BulbaCourses.Analytics.Tests
{
    [TestFixture]
    public class ReportControllerTest
    {
        private IEnumerable<ReportShortDTO> _reportsShorts;
        private IEnumerable<ReportDTO> _reports;

        [OneTimeSetUp]
        public void InitShorts()
        {
            var generator = new Faker<ReportShortDTO>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => _.Commerce.Department());

            int count = 5;
            var reports = generator.Generate(count);

            int number = 1;
            foreach (var report in reports)
            {
                report.Id = number.ToString();
                number++;
            }

            _reportsShorts = (IEnumerable<ReportShortDTO>)reports;
        }

        [OneTimeSetUp]
        public void Init()
        {
            var generator = new Faker<ReportDTO>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => _.Commerce.Department())
                .RuleFor(d => d.Description, _ => "Description Department. Stars " + _.Random.Int(1, 5).ToString())
                .RuleFor(d => d.NumberOfDashboards, _ => _.Random.Int(1, 5));

            int count = 5;
            var reports = generator.Generate(count);

            int number = 1;
            foreach (var report in reports)
            {
                report.Id = number.ToString();
                number++;
            }

            _reports = (IEnumerable<ReportDTO>)reports;
        }

        [Test]
        public void ShowReportById()
        {
            var mock = new Mock<IReportService>();
            mock.Setup(_ => _.GetReportById("1")).Returns(_reports.First());

            ReportsController reportController = new ReportsController(mock.Object);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReportDTO, ReportViewModel>()).CreateMapper();
            var report = mapper.Map<ReportDTO, ReportViewModel>(mock.Object.GetReportById("1"));

            var result = ((OkNegotiatedContentResult<ReportViewModel>)reportController.ShowReportById("1"));
            
            result.Content.Name.Should().Be(_reports.First().Name);
        }

        [Test]
        public void TestShowAll()
        {
            var mock = new Mock<IReportService>();
            mock.Setup(_ => _.GetReportsShort()).Returns(_reportsShorts);

            ReportsController reportController = new ReportsController(mock.Object);

            var result = (OkNegotiatedContentResult<List<ReportViewModel>>)reportController.ShowAll();

            result.Content.Should().BeEquivalentTo(_reportsShorts);

        }
    }
}
