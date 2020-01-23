using Presentations.Logic.Repositories;
using Presentations.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;
using Presentations.Logic.Models;
using BulbaCourses.TextMaterials_Presentations.Data;
using Moq;
using AutoMapper;
using Presentations.Logic.Interfaces;
using System.Data.Entity.Infrastructure;

namespace TextMaterials_Presentations_Tests.ServicesTest
{
    [TestFixture]
    public class FeedbackServiceTest
    {
        private IFeedbacksService _service;
        Mock<IUnitOfWorkRepository> _mockUnitRepo;

        Mapper _mapper;

        List<FeedbackDB> _listFeedbackDB;
        List<FeedbackAdd_DTO> _listFeedbackAdd_DTO;

        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeedbackAdd_DTO, FeedbackDB>();
                cfg.CreateMap<Feedback, FeedbackDB>()
                    .ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitRepo = new Mock<IUnitOfWorkRepository>();
            _service = new FeedbackService(_mockUnitRepo.Object, _mapper);
        }

        [SetUp]
        public void Initialize()
        {
            _listFeedbackDB = new List<FeedbackDB>()
            {
                new FeedbackDB(){ Text = "1"},
                new FeedbackDB(){ Text = "2"},
                new FeedbackDB(){ Text = "3"}
            };

            _listFeedbackAdd_DTO = new List<FeedbackAdd_DTO>()
            {
                new FeedbackAdd_DTO(){ Text = "1"},
                new FeedbackAdd_DTO(){ Text = "2"},
                new FeedbackAdd_DTO(){ Text = "3"}
            };
        }

        [Test]
        public async Task GetAllFeedbacksAsync_Test()
        {
            _mockUnitRepo.Setup(_ => _.Feedbacks.GetAllAsync())
                         .Returns(Task.FromResult(_listFeedbackDB as IEnumerable<FeedbackDB>));

            var expectedResult = _mapper.Map<IEnumerable<FeedbackDB>, IEnumerable<Feedback>>(_listFeedbackDB) as List<Feedback>;

            var result = await _service.GetAllFeedbacksAsync() as List<Feedback>;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddFeedbackAsync_Test()
        {
            var add_DTO = _listFeedbackAdd_DTO.FirstOrDefault();
            var forAdd = _mapper.Map<FeedbackDB>(add_DTO);
            Feedback whasAdded = null;

            _mockUnitRepo.Setup(_ => _.Feedbacks.Add(forAdd));

            _mockUnitRepo.Setup(_ => _.SaveAsync())
                         .Callback(() => { whasAdded = _mapper.Map<Feedback>(forAdd); });

            var result = await _service.AddFeedbackAsync(add_DTO);

            result.IsError.Should().BeFalse();
            result.Data.Text.Should().BeEquivalentTo(whasAdded.Text);//becouse result and whasAdded are from different mapping add_DTO
        }

        [Test]
        public async Task GetFeedbackByIdAsync_Test()
        {
            var feedbackDB = _listFeedbackDB.FirstOrDefault();
            string id = feedbackDB.Id;

            _mockUnitRepo.Setup(_ => _.Feedbacks.GetByIdAsync(id))
                         .Returns(Task.FromResult(feedbackDB));

            var expectedResult = _mapper.Map<Feedback>(feedbackDB);

            var result = await _service.GetFeedbackByIdAsync(id) as Feedback;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task UpdateFeedbackAsync_Test()
        {
            var feedbackDB = _listFeedbackDB.FirstOrDefault();
            Feedback whasUpdated = _mapper.Map<Feedback>(feedbackDB);

            _mockUnitRepo.Setup(_ => _.Feedbacks.Update(feedbackDB))
                         .Callback(() => { feedbackDB.Text = "Updated"; });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.UpdateFeedbackAsync(whasUpdated);

            result.IsError.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(whasUpdated);
        }

        [Test]
        public async Task DeleteFeedbackAsync_Test()
        {
            var del = _listFeedbackDB.FirstOrDefault();

            _mockUnitRepo.Setup(_ => _.Feedbacks.DeleteById(It.IsAny<string>()))
                .Callback((string id) =>
                {
                    _listFeedbackDB.Remove(del);
                });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.DeleteFeedbackByIdAsync(del.Id);

            result.IsError.Should().BeFalse();
            Assert.IsFalse(_listFeedbackDB.Contains(del));
        }
    }
}
