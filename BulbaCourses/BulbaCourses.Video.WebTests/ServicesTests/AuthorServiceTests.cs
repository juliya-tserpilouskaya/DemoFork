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
using System.Threading.Tasks;

namespace BulbaCourses.Video.WebTests.ServicesTests
{
    [TestFixture]
    public class AuthorServiceTests
    {
        private Faker<AuthorDb> _fakerAuthorsDb;
        private IQueryable<AuthorDb> _autorsDb;
        private AuthorDb _oneAuthorDb;
        private IQueryable<AuthorInfo> _authorsInfo;
        private AuthorInfo _oneAuthorInfo;
        private List<CourseDb> _coursesDb;
        private List<CourseInfo> _coursesInfo;
        private Mock<DbSet<AuthorDb>> _mockSet;
        private Mock<VideoDbContext> _mockContext;
        private AuthorRepository _mockRepo;
        private Mock<IMapper> _mockMapper;
        private AuthorService _service;


        [OneTimeSetUp]
        public void Init()
        {
            Faker<AuthorDb> fakerAuthorsDb = new Faker<AuthorDb>();
            fakerAuthorsDb.RuleFor(u => u.AuthorId, b => b.Random.String(8))
                .RuleFor(u => u.Name, b => b.Internet.UserName())
                .RuleFor(u => u.Lastname, b => b.Internet.UserName())
                .RuleFor(u => u.Annotation, b => b.Random.String(25))
                .RuleFor(u => u.Professions, b => b.Random.String(12));
        }

        [SetUp]
        public void InitMock()
        {
            _coursesDb = new List<CourseDb>() {
                new CourseDb(){ CourseId = "idCourse1", Name = "Course1", Price = 10, Date = DateTime.Now, Description = "Description1", Duration = 15, Level = 1, Raiting = 5 },
                new CourseDb(){ CourseId = "idCourse2", Name = "Course2", Price = 20, Date = DateTime.Now, Description = "Description2", Duration = 25, Level = 2, Raiting = 4 },
                new CourseDb(){ CourseId = "idCourse3", Name = "Course3", Price = 30, Date = DateTime.Now, Description = "Description3", Duration = 35, Level = 2, Raiting = 3 }
            };

            _coursesInfo = new List<CourseInfo>() {
                new CourseInfo(){ Name = "Course1", Price = 10, Description = "Description1", Duration = 15, Level = 1, Raiting = 5 },
                new CourseInfo(){ Name = "Course2", Price = 20, Description = "Description2", Duration = 25, Level = 2, Raiting = 4 },
                new CourseInfo(){ Name = "Course3", Price = 30, Description = "Description3", Duration = 35, Level = 2, Raiting = 3 }
            };

            _autorsDb = new List<AuthorDb>() {
                new AuthorDb(){ AuthorId = "id1", Name = "name1", Lastname = "lastname1", Annotation = "Annotation1", Professions = "Professions1", AuthorCourses = _coursesDb},
                new AuthorDb(){ AuthorId = "id2", Name = "name2", Lastname = "lastname2", Annotation = "Annotation2", Professions = "Professions2" },
                new AuthorDb(){ AuthorId = "id3", Name = "name3", Lastname = "lastname3", Annotation = "Annotation3", Professions = "Professions3" }
            }.AsQueryable();

            _oneAuthorDb = new AuthorDb() { AuthorId = "id4", Name = "name4", Lastname = "lastname4", Annotation = "Annotation4", Professions = "Professions4" };

            _authorsInfo = new List<AuthorInfo>() {
                new AuthorInfo(){ Name = "name1", Lastname = "lastname1", Annotation = "Annotation1", Professions = "Professions1" },
                new AuthorInfo(){ Name = "name2", Lastname = "lastname2", Annotation = "Annotation2", Professions = "Professions2" },
                new AuthorInfo(){ Name = "name3", Lastname = "lastname3", Annotation = "Annotation3", Professions = "Professions3" }
            }.AsQueryable();

            _oneAuthorInfo = new AuthorInfo() { Name = "name4", Lastname = "lastname4", Annotation = "Annotation4", Professions = "Professions4" };

            _mockSet = new Mock<DbSet<AuthorDb>>();
            _mockSet.As<IQueryable<AuthorDb>>().Setup(m => m.Expression).Returns(_autorsDb.Expression);
            _mockSet.As<IQueryable<AuthorDb>>().Setup(m => m.ElementType).Returns(_autorsDb.ElementType);
            _mockSet.As<IQueryable<AuthorDb>>().Setup(m => m.GetEnumerator()).Returns(_autorsDb.GetEnumerator());
            _mockContext = new Mock<VideoDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void Test_GetAll_Authors_Courses()
        {
            _mockSet.As<IQueryable<AuthorDb>>().Setup(m => m.Provider).Returns(_autorsDb.Provider);

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<AuthorInfo, AuthorDb>(_authorsInfo.First())).Returns(_autorsDb.First());
            _mockMapper.Setup(m => m.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(_coursesDb)).Returns(_coursesInfo);
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var courses = _service.GetAllCourses(_authorsInfo.First());
            courses.Count().Should().Be(_coursesDb.Count);
            courses.First().Should().Be(_coursesInfo.First());
            courses.Should().BeEquivalentTo(_coursesInfo);
        }

        [Test]
        public async Task Test_GettAll_Author_Async()
        {

            _mockSet.As<IDbAsyncEnumerable<AuthorDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AuthorDb>(_autorsDb.GetEnumerator()));
            _mockSet.As<IQueryable<AuthorDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<AuthorDb>(_autorsDb.Provider));

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<IEnumerable<AuthorDb>, IEnumerable<AuthorInfo>>(_autorsDb)).Returns(_authorsInfo);
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var authors = await _service.GetAllAsync();

            authors.Should().BeEquivalentTo(_authorsInfo);
            authors.Count().Should().Be(_authorsInfo.Count());
            authors.First().Name.Should().Be(_authorsInfo.First().Name);
        }

        [Test]
        public async Task Test_GetById_Author_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<AuthorDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AuthorDb>(_autorsDb.GetEnumerator()));
            _mockSet.As<IQueryable<AuthorDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<AuthorDb>(_autorsDb.Provider));

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<AuthorDb, AuthorInfo>(_autorsDb.First())).Returns(_authorsInfo.First());
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var author = await _service.GetByIdAsync(_autorsDb.First().AuthorId);
            author.Should().Be(_authorsInfo.First());
            author.Name.Should().Be("name1");
        }

        [Test]
        public async Task Test_Create_Author_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<AuthorDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AuthorDb>(_autorsDb.GetEnumerator()));
            _mockSet.As<IQueryable<AuthorDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<AuthorDb>(_autorsDb.Provider));

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<AuthorInfo, AuthorDb>(_oneAuthorInfo)).Returns(_oneAuthorDb);
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var result = await _service.AddAsync(_oneAuthorInfo);
            _mockSet.Verify(b => b.Add(It.IsAny<AuthorDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_Delete_Author_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<AuthorDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AuthorDb>(_autorsDb.GetEnumerator()));
            _mockSet.As<IQueryable<AuthorDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<AuthorDb>(_autorsDb.Provider));

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<AuthorInfo, AuthorDb>(_oneAuthorInfo)).Returns(_oneAuthorDb);
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var result = await _service.DeleteAsync(_oneAuthorInfo);
            _mockSet.Verify(b => b.Remove(It.IsAny<AuthorDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_DeleteById_Author_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<AuthorDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AuthorDb>(_autorsDb.GetEnumerator()));
            _mockSet.As<IQueryable<AuthorDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<AuthorDb>(_autorsDb.Provider));

            _mockContext.Setup(c => c.Authors).Returns(_mockSet.Object);
            _mockRepo = new AuthorRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<AuthorDb, AuthorInfo>(_autorsDb.First())).Returns(_authorsInfo.First());
            _service = new AuthorService(_mockMapper.Object, _mockRepo);
            var result = await _service.DeleteByIdAsync(_autorsDb.First().AuthorId);
            _mockSet.Verify(b => b.Remove(It.IsAny<AuthorDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }
    }
}
