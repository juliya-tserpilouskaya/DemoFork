using AutoMapper;
using BulbaCourses.Analytics.BLL.Interface;
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
        private List<ReportShortDto> _reportDtos;
        private List<ReportShortVm> _reportVms;
        private Mock<IMapper> _mockMapper;
        private Mock<IReportsService> _mockReportService;
        private Mock<IValidation> _mockValidation;

        [SetUp]
        public void InitGetAll()
        {
            _reportDtos = new List<ReportShortDto>() { new ReportShortDto { Id = "id", Name = "Name" } };
            _reportVms = new List<ReportShortVm>() { new ReportShortVm { Id = "id", Name = "Name" } };

            _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(v => v.Map<IEnumerable<ReportShortVm>>(_reportDtos)).Returns(_reportVms);

            _mockReportService = new Mock<IReportsService>();
            _mockValidation = new Mock<IValidation>();

        }

        [Test]
        public void GetAllBeOk()
        {
            _mockReportService.Setup(v => v.GetAll()).Returns(_reportDtos);
            _mockValidation.Setup(v => v.IsErrors).Returns(false);

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object, _mockValidation.Object);

            var result = (OkNegotiatedContentResult<IEnumerable<ReportShortVm>>)reportsController.GetAll();
            result.Content.Should().BeEquivalentTo(_reportVms);
        }

        [Test]
        public void GetAllBeNotFound()
        {
            _mockReportService.Setup(v => v.GetAll()).Returns(_reportDtos);

            _mockValidation.Setup(v => v.IsErrors).Returns(true);
            _mockValidation.Setup(v => v.Error).Returns(new ErrorContainer(new Dictionary<string, string>()));

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object, _mockValidation.Object);

            var expected = new ErrorContainer(new Dictionary<string, string>());

            var result = (NegotiatedContentResult<ErrorContainer>)reportsController.GetAll();

            result.Content.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetAllBeInvalidOperationException()
        {
            _mockReportService.Setup(v => v.GetAll()).Throws<InvalidOperationException>();

            _mockValidation.Setup(v => v.IsErrors).Returns(true);             

            ReportsController reportsController = new ReportsController(_mockReportService.Object, _mockMapper.Object, _mockValidation.Object);

            var result = (InternalServerErrorResult)reportsController.GetAll(); 

            result.Should().NotBeNull();
        }
    }
}
