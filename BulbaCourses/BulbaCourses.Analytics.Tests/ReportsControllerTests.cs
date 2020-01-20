using AutoMapper;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Infrastructure.Models;
using BulbaCourses.Analytics.Models.V1;
using BulbaCourses.Analytics.Web.Controllers.V1;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace BulbaCourses.Analytics.Tests
{
    [TestFixture]
    public class ReportsControllerTests
    {
        private List<ReportDto> _reportDtos;
        private List<ReportShort> _reportShorts;
        private Mock<IMapper> _mockMapper;
        private Mock<IReportsService> _mockReportService;

        [SetUp]
        public void InitGetAll()
        {
            _reportDtos = new List<ReportDto>() { new ReportDto { Id = "id", Name = "Name" } };
            _reportShorts = new List<ReportShort>() { new ReportShort { Id = "id", Name = "Name" } };

            _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(v => v.Map<IEnumerable<ReportShort>>(_reportDtos)).Returns(_reportShorts);

            _mockReportService = new Mock<IReportsService>();
        }

        [Test]
        public void GetAllBeOk()
        {
            _mockReportService.SetupAsync(v => v.GetAllAsync()).Returns(_reportDtos);

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object);

            var result = (OkNegotiatedContentResult<IEnumerable<ReportShort>>)reportsController.GetAll().Result;
            result.Content.Should().BeEquivalentTo(_reportShorts);
        }

        [Test]
        public void GetAllBeNotFound()
        {
            var freeReportDtos = new List<ReportDto>();
            _mockReportService.SetupAsync(v => v.GetAllAsync()).Returns(freeReportDtos);

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object);

            var result = (NotFoundResult)reportsController.GetAll().Result;

            result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public void GetAllBeInvalidOperationException()
        {
            _mockReportService.SetupAsync(v => v.GetAllAsync()).Throws<InvalidOperationException>();

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object);

            var result = (ExceptionResult)reportsController.GetAll().Result;

            result.Exception.Should().BeOfType<InvalidOperationException>();
        }
    }
}
