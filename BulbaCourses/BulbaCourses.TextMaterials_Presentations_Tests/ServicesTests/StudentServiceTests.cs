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
    public class StudentServiceTests
    {
        private IStudentService _service;
        Mock<IUnitOfWorkRepository> _mockUnitRepo;

        Mapper _mapper;

        List<StudentDB> _listStudentDB;
        List<UserAdd_DTO> _listStudentAdd_DTO;

        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserAdd_DTO, StudentDB>();
                cfg.CreateMap<Student, StudentDB>()
                    .ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitRepo = new Mock<IUnitOfWorkRepository>();
            _service = new StudentService(_mockUnitRepo.Object, _mapper);
        }

        [SetUp]
        public void Initialize()
        {
            _listStudentDB = new List<StudentDB>()
            {
                new StudentDB(){ PhoneNumber = "1", Created = DateTime.Now},
                new StudentDB(){ PhoneNumber = "2", Created = DateTime.Now},
                new StudentDB(){ PhoneNumber = "3", Created = DateTime.Now}
            };

            _listStudentAdd_DTO = new List<UserAdd_DTO>()
            {
                new UserAdd_DTO(){ PhoneNumber = "4"},
                new UserAdd_DTO(){ PhoneNumber = "5"},
                new UserAdd_DTO(){ PhoneNumber = "6"}
            };
        }

        [Test]
        public async Task GetAllStudentsAsync_Test()
        {
            _mockUnitRepo.Setup(_ => _.Students.GetAllAsync())
                         .Returns(Task.FromResult(_listStudentDB as IEnumerable<StudentDB>));

            var expectedResult = _mapper.Map<IEnumerable<StudentDB>, IEnumerable<Student>>(_listStudentDB) as List<Student>;

            var result = await _service.GetAllStudentsAsync() as List<Student>;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddStudentAsync_Test()
        {
            var add_DTO = _listStudentAdd_DTO.FirstOrDefault();
            var forAdd = _mapper.Map<StudentDB>(add_DTO);
            Student whasAdded = null;

            _mockUnitRepo.Setup(_ => _.Students.Add(forAdd));

            _mockUnitRepo.Setup(_ => _.SaveAsync())
                         .Callback(() => { whasAdded = _mapper.Map<Student>(forAdd); });

            var result = await _service.AddStudentAsync(add_DTO);

            result.IsError.Should().BeFalse();
            result.Data.PhoneNumber.Should().BeEquivalentTo(whasAdded.PhoneNumber);//becouse result and whasAdded are from different mapping add_DTO
        }

        [Test]
        public async Task GetStudentByIdAsync_Test()
        {
            var studentDB = _listStudentDB.FirstOrDefault();
            string id = studentDB.Id;

            _mockUnitRepo.Setup(_ => _.Students.GetByIdAsync(id))
                         .Returns(Task.FromResult(studentDB));

            var expectedResult = _mapper.Map<Student>(studentDB);

            var result = await _service.GetStudentByIdAsync(id) as Student;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task UpdateStudentAsync_Test()
        {
            var studentDB = _listStudentDB.FirstOrDefault();
            Student whasUpdated = _mapper.Map<Student>(studentDB);

            _mockUnitRepo.Setup(_ => _.Students.Update(studentDB))
                         .Callback(() => { studentDB.PhoneNumber = "Updated"; });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.UpdateStudentAsync(whasUpdated);

            result.IsError.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(whasUpdated);
        }

        [Test]
        public async Task DeleteStudentAsync_Test()
        {
            var del = _listStudentDB.FirstOrDefault();

            _mockUnitRepo.Setup(_ => _.Students.DeleteById(It.IsAny<string>()))
                .Callback((string id) =>
                {
                    _listStudentDB.Remove(del);
                });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.DeleteStudentByIdAsync(del.Id);

            result.IsError.Should().BeFalse();
            Assert.IsFalse(_listStudentDB.Contains(del));
        }
    }
}
