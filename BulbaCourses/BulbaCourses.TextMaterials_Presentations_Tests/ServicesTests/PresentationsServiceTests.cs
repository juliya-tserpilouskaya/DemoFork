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
    public class PresentationsServiceTests
    {
        private IPresentationsService _service;
        Mock<IUnitOfWorkRepository> _mockUnitRepo;

        Mapper _mapper;

        List<PresentationDB> _listPresentationDB;
        List<PresentationAdd_DTO> _listPresentationAdd_DTO;

        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PresentationAdd_DTO, PresentationDB>();
                cfg.CreateMap<Presentation, PresentationDB>()
                    .ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitRepo = new Mock<IUnitOfWorkRepository>();
            _service = new PresentationsService(_mockUnitRepo.Object, _mapper);
        }

        [SetUp]
        public void Initialize()
        {
            _listPresentationDB = new List<PresentationDB>()
            {
                new PresentationDB(){ Title = "1", IsAccessible = true},
                new PresentationDB(){ Title = "2", IsAccessible = true},
                new PresentationDB(){ Title = "3", IsAccessible = true}
            };

            _listPresentationAdd_DTO = new List<PresentationAdd_DTO>()
            {
                new PresentationAdd_DTO(){ Title = "1", IsAccessible = true},
                new PresentationAdd_DTO(){ Title = "2", IsAccessible = true},
                new PresentationAdd_DTO(){ Title = "3", IsAccessible = true}
            };
        }

        [Test]
        public async Task GetAllPresentationsAsync_Test()
        {
            _mockUnitRepo.Setup(_ => _.Presentations.GetAllAsync())
                         .Returns(Task.FromResult(_listPresentationDB as IEnumerable<PresentationDB>));

            var expectedResult = _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>
                (_listPresentationDB) as List<Presentation>;

            var result = await _service.GetAllPresentationsAsync() as List<Presentation>;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddPresentationAsync_Test()
        {
            var add_DTO = _listPresentationAdd_DTO.FirstOrDefault();
            var forAdd = _mapper.Map<PresentationDB>(add_DTO);
            Presentation whasAdded = null;

            _mockUnitRepo.Setup(_ => _.Presentations.Add(forAdd));

            _mockUnitRepo.Setup(_ => _.SaveAsync())
                         .Callback(() => { whasAdded = _mapper.Map<Presentation>(forAdd); });

            var result = await _service.AddPresentationAsync(add_DTO);

            result.IsError.Should().BeFalse();
            result.Data.Title.Should().BeEquivalentTo(whasAdded.Title);//becouse result and whasAdded are from different mapping add_DTO
        }

        [Test]
        public async Task GetPresentationByIdAsync_Test()
        {
            var presentationDB = _listPresentationDB.FirstOrDefault();
            string id = presentationDB.Id;

            _mockUnitRepo.Setup(_ => _.Presentations.GetByIdAsync(id))
                         .Returns(Task.FromResult(presentationDB));

            var expectedResult = _mapper.Map<Presentation>(presentationDB);

            var result = await _service.GetPresentationByIdAsync(id) as Presentation;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task UpdatePresentationAsync_Test()
        {
            var presentationDB = _listPresentationDB.FirstOrDefault();
            Presentation whasUpdated = _mapper.Map<Presentation>(presentationDB);

            _mockUnitRepo.Setup(_ => _.Presentations.Update(presentationDB))
                         .Callback(() => { presentationDB.Title = "Updated"; });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.UpdatePresentationAsync(whasUpdated);

            result.IsError.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(whasUpdated);
        }

        [Test]
        public async Task DeletePresentationAsync_Test()
        {
            var del = _listPresentationDB.FirstOrDefault();

            _mockUnitRepo.Setup(_ => _.Presentations.DeleteById(It.IsAny<string>()))
                .Callback((string id) =>
                {
                    _listPresentationDB.Remove(del);
                });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.DeletePresentationByIdAsync(del.Id);

            result.IsError.Should().BeFalse();
            Assert.IsFalse(_listPresentationDB.Contains(del));
        }
    }
}
