using AutoMapper;
using Bogus;
using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Data.Repositories;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.WebTests.ServicesTests
{
    [TestFixture]
    public class CourseServiceTests
    {
        private Faker<CourseDb> _fakerCourseDb;
        private IQueryable<CourseDb> _coursesDb;
        private CourseDb _oneCourseDb;
        private TagDb _tagDb;
        private List<TagDb> _tagDbFirst;
        private List<TagDb> _tagDbSecond;
        private TagInfo _tagInfo;
        private List<TagInfo> _tagInfoFirst;
        private List<TagInfo> _tagInfoSecond;
        private IQueryable<CourseInfo> _coursesInfo;
        private CourseInfo _oneCourseInfo;
        private Mock<DbSet<CourseDb>> _mockSet;
        private Mock<VideoDbContext> _mockContext;
        private CourseRepository _mockRepo;
        private Mock<IMapper> _mockMapper;
        private CourseService _service;

        [SetUp]
        public void InitMock()
        {
            _tagDb = new TagDb() { TagId = "tag1", Content = "C#" };
            _tagDbFirst = new List<TagDb>() {
                _tagDb,
                new TagDb() { TagId = "tag2", Content = "ASP" },
            };
            _tagDbSecond = new List<TagDb>() {
                new TagDb() { TagId = "tag3", Content = "Java" },
                new TagDb() { TagId = "tag4", Content = "Javascript" },
            };
            _tagInfo = new TagInfo() { TagId = "tag1", Content = "C#" };
            _tagInfoFirst = new List<TagInfo>() {
                _tagInfo,
                new TagInfo() { TagId = "tag2", Content = "ASP" },
            };
            _tagInfoSecond = new List<TagInfo>() {
                new TagInfo() { TagId = "tag3", Content = "Java" },
                new TagInfo() { TagId = "tag4", Content = "Javascript" },
            };

            _coursesDb = new List<CourseDb>() {
                new CourseDb(){ CourseId = "idCourse1", Name = "Course1", Price = 10, Date = DateTime.Now, Description = "Description1", Duration = 15, Level = 1, Raiting = 5, RateCount = 3, Tags = _tagDbFirst },
                new CourseDb(){ CourseId = "idCourse2", Name = "Course2", Price = 20, Date = DateTime.Now, Description = "Description2", Duration = 25, Level = 2, Raiting = 4, RateCount = 10, Tags = _tagDbSecond },
                new CourseDb(){ CourseId = "idCourse3", Name = "Course3", Price = 30, Date = DateTime.Now, Description = "Description3", Duration = 35, Level = 2, Raiting = 3, RateCount = 15, Tags = _tagDbSecond},
                new CourseDb(){ CourseId = "idCourse4", Name = "Course4", Price = 40, Date = DateTime.Now, Description = "Description4", Duration = 45, Level = 1, Raiting = 2, RateCount = 12, Tags = _tagDbFirst  },
                new CourseDb(){ CourseId = "idCourse5", Name = "Course5", Price = 50, Date = DateTime.Now, Description = "Description5", Duration = 55, Level = 2, Raiting = 3, RateCount = 24, Tags = _tagDbFirst  },
            }.AsQueryable();

            _coursesInfo = new List<CourseInfo>() {
                new CourseInfo(){ Name = "Course1", Price = 10, Description = "Description1", Duration = 15, Level = 1, Raiting = 5},
                new CourseInfo(){ Name = "Course2", Price = 20, Description = "Description2", Duration = 25, Level = 2, Raiting = 4 },
                new CourseInfo(){ Name = "Course3", Price = 30, Description = "Description3", Duration = 35, Level = 2, Raiting = 3 },
                new CourseInfo(){ Name = "Course4", Price = 40, Description = "Description4", Duration = 45, Level = 1, Raiting = 2 },
                new CourseInfo(){ Name = "Course5", Price = 50, Description = "Description5", Duration = 55, Level = 2, Raiting = 3 }
            }.AsQueryable();

            _oneCourseDb = new CourseDb() { CourseId = "idCourseFirst", Name = "CourseFirst", Price = 40, Date = DateTime.Now, Description = "DescriptionFirst", Duration = 45, Level = 1, Raiting = 5 };
            _oneCourseInfo = new CourseInfo() { Name = "CourseFirst", Price = 40, Description = "DescriptionFirst", Duration = 45, Level = 1, Raiting = 5 };
            
            //_autorsDb = new List<AuthorDb>() {
            //    new AuthorDb(){ AuthorId = "id1", Name = "name1", Lastname = "lastname1", Annotation = "Annotation1", Professions = "Professions1", AuthorCourses = _coursesDb},
            //    new AuthorDb(){ AuthorId = "id2", Name = "name2", Lastname = "lastname2", Annotation = "Annotation2", Professions = "Professions2" },
            //    new AuthorDb(){ AuthorId = "id3", Name = "name3", Lastname = "lastname3", Annotation = "Annotation3", Professions = "Professions3" }
            //}.AsQueryable();

            //_oneAuthorDb = new AuthorDb() { AuthorId = "id4", Name = "name4", Lastname = "lastname4", Annotation = "Annotation4", Professions = "Professions4" };

            //_authorsInfo = new List<AuthorInfo>() {
            //    new AuthorInfo(){ Name = "name1", Lastname = "lastname1", Annotation = "Annotation1", Professions = "Professions1" },
            //    new AuthorInfo(){ Name = "name2", Lastname = "lastname2", Annotation = "Annotation2", Professions = "Professions2" },
            //    new AuthorInfo(){ Name = "name3", Lastname = "lastname3", Annotation = "Annotation3", Professions = "Professions3" }
            //}.AsQueryable();

            //_oneAuthorInfo = new AuthorInfo() { Name = "name4", Lastname = "lastname4", Annotation = "Annotation4", Professions = "Professions4" };

            _mockSet = new Mock<DbSet<CourseDb>>();
            _mockSet.As<IQueryable<CourseDb>>().Setup(m => m.Expression).Returns(_coursesDb.Expression);
            _mockSet.As<IQueryable<CourseDb>>().Setup(m => m.ElementType).Returns(_coursesDb.ElementType);
            _mockSet.As<IQueryable<CourseDb>>().Setup(m => m.GetEnumerator()).Returns(_coursesDb.GetEnumerator());
            _mockContext = new Mock<VideoDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public async Task Test_GettAll_Courses_Async()
        {

            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(_coursesDb)).Returns(_coursesInfo);
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var courses = await _service.GetAllAsync();

            courses.Should().BeEquivalentTo(_coursesInfo);
            courses.Count().Should().Be(_coursesInfo.Count());
            courses.First().Name.Should().Be(_coursesInfo.First().Name);
        }

        [Test]
        public async Task Test_GetById_Course_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CourseDb, CourseInfo>(_coursesDb.First())).Returns(_coursesInfo.First());
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var course = await _service.GetCourseByIdAsync(_coursesDb.First().CourseId);
            course.Should().Be(_coursesInfo.First());
            course.Name.Should().Be("Course1");
        }

        [Test]
        public async Task Test_GetByName_Course_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(_coursesDb)).Returns(_coursesInfo);
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var courses = await _service.GetCoursesByNameAsync("Course");
            courses.Count().Should().Be(5);
            courses.First().Name.Should().Be(_coursesInfo.First().Name);
        }

        //[Test]
        //public async Task Test_GetList_Course_ByTag_Async()
        //{
        //    _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
        //    _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

        //    _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
        //    _mockRepo = new CourseRepository(_mockContext.Object);
        //    _mockMapper.Setup(m => m.Map<TagInfo, TagDb>(_tagInfo)).Returns(_tagDb);
        //    _mockMapper.Setup(m => m.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(_coursesDb)).Returns(_coursesInfo);

        //    _service = new CourseService(_mockMapper.Object, _mockRepo);
        //    var courses = await _service.GetListByTagAsync(_tagInfo);
        //    courses.Count().Should().Be(3);
        //}

        [Test]
        public async Task Test_Create_Course_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CourseInfo, CourseDb>(_oneCourseInfo)).Returns(_oneCourseDb);
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var result = await _service.AddCourseAsync(_oneCourseInfo);
            _mockSet.Verify(b => b.Add(It.IsAny<CourseDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_DeleteById_Course_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CourseDb, CourseInfo>(_coursesDb.First())).Returns(_coursesInfo.First());
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var result = await _service.DeleteByIdAsync(_coursesDb.First().CourseId);
            _mockSet.Verify(b => b.Remove(It.IsAny<CourseDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_Exist_Course_ByName()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            string name = _coursesDb.First().Name;
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var result = await _service.ExistNameAsync(name);
            result.Should().BeTrue();
        }
        [Test]
        public async Task Test_Negative_Exist_Course_ByName()
        {
            _mockSet.As<IDbAsyncEnumerable<CourseDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CourseDb>(_coursesDb.GetEnumerator()));
            _mockSet.As<IQueryable<CourseDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CourseDb>(_coursesDb.Provider));

            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _mockRepo = new CourseRepository(_mockContext.Object);
            string name = "RandomeName";
            _service = new CourseService(_mockMapper.Object, _mockRepo);
            var result = await _service.ExistNameAsync(name);
            result.Should().BeFalse();
        }

    }
}
