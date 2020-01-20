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
    public class CourseServiceTests
    {
        private ICoursesService _service;
        Mock<IUnitOfWorkRepository> _mockUnitRepo;

        Mapper _mapper;

        List<CourseDB> _listCourseDB;
        List<CourseAdd_DTO> _listCourseAdd_DTO;

        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseAdd_DTO, CourseDB>();
                cfg.CreateMap<Course, CourseDB>()
                    .ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _mockUnitRepo = new Mock<IUnitOfWorkRepository>();
            _service = new CourseService(_mockUnitRepo.Object, _mapper);
        }

        [SetUp]
        public void Initialize()
        {
            _listCourseDB = new List<CourseDB>()
            {
                new CourseDB(){ Name = "1"},
                new CourseDB(){ Name = "2"},
                new CourseDB(){ Name = "3"}
            };

            _listCourseAdd_DTO = new List<CourseAdd_DTO>()
            {
                new CourseAdd_DTO(){ Name = "1"},
                new CourseAdd_DTO(){ Name = "2"},
                new CourseAdd_DTO(){ Name = "3"}
            };
        }

        [Test]
        public async Task GetAllCoursesAsync_Test()
        {
            _mockUnitRepo.Setup(_ => _.Courses.GetAllAsync())
                         .Returns(Task.FromResult(_listCourseDB as IEnumerable<CourseDB>));
                        
            var expectedResult = _mapper.Map<IEnumerable<CourseDB>, IEnumerable<Course>>(_listCourseDB) as List<Course>;

            var result = await _service.GetAllCoursesAsync() as List<Course>;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddCourseAsync_Test()
        {
            var add_DTO = _listCourseAdd_DTO.FirstOrDefault();
            var forAdd = _mapper.Map<CourseDB>(add_DTO);
            Course whasAdded = null;

            _mockUnitRepo.Setup(_ => _.Courses.Add(forAdd));

            _mockUnitRepo.Setup(_ => _.SaveAsync())
                         .Callback(() => { whasAdded = _mapper.Map<Course>(forAdd); });

            var result = await _service.AddCourseAsync(add_DTO);

            result.IsError.Should().BeFalse();
            result.Data.Name.Should().BeEquivalentTo(whasAdded.Name);//becouse result and whasAdded are from different mapping add_DTO
        }

        [Test]
        public async Task GetCourseByIdAsync_Test()
        {
            var coursDB = _listCourseDB.FirstOrDefault();
            string id = coursDB.Id;

            _mockUnitRepo.Setup(_ => _.Courses.GetByIdAsync(id))
                         .Returns(Task.FromResult(coursDB));

            var expectedResult = _mapper.Map<Course>(coursDB);

            var result = await _service.GetCourseByIdAsync(id) as Course;

            expectedResult.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task UpdateCourseAsync_Test()
        {
            var coursDB = _listCourseDB.FirstOrDefault();
            Course whasUpdated = _mapper.Map<Course>(coursDB); ;

            _mockUnitRepo.Setup(_ => _.Courses.Update(coursDB))
                         .Callback(()=> { coursDB.Name = "Updated"; });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.UpdateCourseAsync(whasUpdated);

            result.IsError.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(whasUpdated);
        }

        [Test]
        public async Task DeleteCourseAsync_Test()
        {
            var del = _listCourseDB.FirstOrDefault();

            _mockUnitRepo.Setup(_ => _.Courses.DeleteById(It.IsAny<string>()))
                .Callback((string id) =>
                {
                    _listCourseDB.Remove(del);
                });

            _mockUnitRepo.Setup(_ => _.SaveAsync());

            var result = await _service.DeleteCourseByIdAsync(del.Id);

            result.IsError.Should().BeFalse();
            Assert.IsFalse(_listCourseDB.Contains(del));
        }
    }
}
