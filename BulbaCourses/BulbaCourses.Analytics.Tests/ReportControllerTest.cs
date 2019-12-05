using AutoMapper;
using Bogus;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Web.Controllers;
using BulbaCourses.Analytics.Web.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace BulbaCourses.Analytics.Tests
{
    [TestFixture]
    public class ReportControllerTest
    {
        private IEnumerable<ReportDto> _reportsShorts;
        private IEnumerable<ReportDto> _reports;

        [OneTimeSetUp]
        public void InitShorts()
        {
            var generator = new Faker<ReportDto>()
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

            _reportsShorts = (IEnumerable<ReportDto>)reports;
        }

        [OneTimeSetUp]
        public void Init()
        {
            var generator = new Faker<ReportDto>()
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

            _reports = (IEnumerable<ReportDto>)reports;
        }

        [Test]
        public void ShowReportById()
        {
            var mock = new Mock<ReportService>();
            mock.Setup(_ => _.GetById("1")).Returns(_reports.First());

            ReportsController reportController = new ReportsController(mock.Object);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReportDto, ReportVm>()).CreateMapper();
            var report = mapper.Map<ReportDto, ReportVm>(mock.Object.GetById("1"));

            var result = ((OkNegotiatedContentResult<ReportVm>)reportController.ShowReportById("1"));

            result.Content.Name.Should().Be(_reports.First().Name);
        }

        [Test]
        public void TestShowAll()
        {
            var mock = new Mock<ReportService>();
            mock.Setup(_ => _.GetAll()).Returns(_reportsShorts);

            ReportsController reportController = new ReportsController(mock.Object);

            var result = (OkNegotiatedContentResult<List<ReportVm>>)reportController.ShowAll();

            result.Content.Should().BeEquivalentTo(_reportsShorts);

        }
    }
}
