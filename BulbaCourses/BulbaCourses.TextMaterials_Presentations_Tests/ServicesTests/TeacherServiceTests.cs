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
using Presentations.Logic;

namespace TextMaterials_Presentations_Tests.ServicesTest
{
    [TestFixture]
    public class TeacherServiceTests
    {
        private ITeacherService _service;
        Mock<IUnitOfWorkRepository> _mockUnitRepo;

        Mapper _mapper;

        List<TeacherDB> _listTeacherDB;
        List<TeacherAdd_DTO> _listTeacherAdd_DTO;

        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherAdd_DTO, TeacherDB>();
                cfg.CreateMap<Teacher, TeacherDB>()
                    .ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitRepo = new Mock<IUnitOfWorkRepository>();
            _service = new TeacherService(_mockUnitRepo.Object, _mapper);
        }

        [SetUp]
        public void Initialize()
        {
            _listTeacherDB = new List<TeacherDB>()
            {
                new TeacherDB(){ PhoneNumber = "1", Created = DateTime.Now},
                new TeacherDB(){ PhoneNumber = "2", Created = DateTime.Now},
                new TeacherDB(){ PhoneNumber = "3", Created = DateTime.Now}
            };

            _listTeacherAdd_DTO = new List<TeacherAdd_DTO>()
            {
                new TeacherAdd_DTO(){ PhoneNumber = "4"},
                new TeacherAdd_DTO(){ PhoneNumber = "5"},
                new TeacherAdd_DTO(){ PhoneNumber = "6"}
            };
        }

        [Test]
        public async Task GetAllTeachersAsync_Test()
        {
            _mockUnitRepo.Setup(_ => _.Teachers.GetAllAsync())
                         .Returns(Task.FromResult(_listTeacherDB as IEnumerable<TeacherDB>));

            var expectedResult = _mapper.Map<IEnumerable<TeacherDB>, IEnumerable<Teacher>>(_listTeacherDB) as List<Teacher>;

            var result = await _service.GetAllTeachersAsync() as List<Teacher>;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddTeacherAsync_Test()
        {
            var add_DTO = _listTeacherAdd_DTO.FirstOrDefault();
            var forAdd = _mapper.Map<TeacherDB>(add_DTO);
            Teacher whasAdded = null;

            _mockUnitRepo.Setup(_ => _.Teachers.Add(forAdd));

            _mockUnitRepo.Setup(_ => _.SaveAsync())
                         .Callback(() => { whasAdded = _mapper.Map<Teacher>(forAdd); });

            var result = await _service.AddTeacherAsync(add_DTO);

            result.IsError.Should().BeFalse();
            result.Data.PhoneNumber.Should().BeEquivalentTo(whasAdded.PhoneNumber);//becouse result and whasAdded are from different mapping add_DTO
        }

        [Test]
        public async Task GetTeacherByIdAsync_Test()
        {
            var teacherDB = _listTeacherDB.FirstOrDefault();
            string id = teacherDB.Id;

            _mockUnitRepo.Setup(_ => _.Teachers.GetByIdAsync(id))
                         .Returns(Task.FromResult(teacherDB));

            var expectedResult = _mapper.Map<Teacher>(teacherDB);

            var result = await _service.GetTeacherByIdAsync(id) as Teacher;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task UpdateTeacherAsync_Test()
        {
            var teacherDB = _listTeacherDB.FirstOrDefault();
            Teacher whasUpdated = _mapper.Map<Teacher>(teacherDB);

            _mockUnitRepo.Setup(_ => _.Teachers.Update(teacherDB))
                         .Callback(() => { teacherDB.PhoneNumber = "Updated"; });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.UpdateTeacherAsync(whasUpdated);

            result.IsError.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(whasUpdated);
        }

        [Test]
        public async Task DeleteTeacherAsync_Test()
        {
            var del = _listTeacherDB.FirstOrDefault();

            _mockUnitRepo.Setup(_ => _.Teachers.DeleteById(It.IsAny<string>()))
                .Callback((string id) =>
                {
                    _listTeacherDB.Remove(del);
                });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.DeleteTeacherByIdAsync(del.Id);

            result.IsError.Should().BeFalse();
            Assert.IsFalse(_listTeacherDB.Contains(del));
        }
    }
}
