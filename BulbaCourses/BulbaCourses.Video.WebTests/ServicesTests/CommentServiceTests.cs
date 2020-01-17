using AutoMapper;
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
    public class CommentServiceTests
    {
        private IQueryable<CommentDb> _commentsDb;
        private CommentDb _oneCommentDb;
        private IQueryable<CommentInfo> _commentsInfo;
        private CommentInfo _oneCommentInfo;
        private Mock<DbSet<CommentDb>> _mockSet;
        private Mock<VideoDbContext> _mockContext;
        private CommentRepository _mockRepo;
        private Mock<IMapper> _mockMapper;
        private CommentService _service;

        [SetUp]
        public void InitMock()
        {

            _commentsDb = new List<CommentDb>() {
                new CommentDb(){ CommentId = "id1", Date = DateTime.Now, Text = "AAAAA"},
                new CommentDb(){ CommentId = "id2", Date = DateTime.Now, Text = "BBBBB"},
                new CommentDb(){ CommentId = "id3", Date = DateTime.Now, Text = "CCCCC"},
            }.AsQueryable();

            _oneCommentDb = new CommentDb() { CommentId = "id4", Date = DateTime.Now, Text = "DDDDD" };

            _commentsInfo = new List<CommentInfo>() {
                new CommentInfo(){ Date = DateTime.Now, Text = "AAAAA", UpdateDate = DateTime.Now},
                new CommentInfo(){ Date = DateTime.Now, Text = "BBBBB", UpdateDate = DateTime.Now},
                new CommentInfo(){ Date = DateTime.Now, Text = "CCCCC", UpdateDate = DateTime.Now}
            }.AsQueryable();

            _oneCommentInfo = new CommentInfo() { Date = DateTime.Now, Text = "DDDDD", UpdateDate = DateTime.Now };

            _mockSet = new Mock<DbSet<CommentDb>>();
            _mockSet.As<IQueryable<CommentDb>>().Setup(m => m.Expression).Returns(_commentsDb.Expression);
            _mockSet.As<IQueryable<CommentDb>>().Setup(m => m.ElementType).Returns(_commentsDb.ElementType);
            _mockSet.As<IQueryable<CommentDb>>().Setup(m => m.GetEnumerator()).Returns(_commentsDb.GetEnumerator());
            _mockContext = new Mock<VideoDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public async Task Test_GettAll_Comments_Async()
        {

            _mockSet.As<IDbAsyncEnumerable<CommentDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CommentDb>(_commentsDb.GetEnumerator()));
            _mockSet.As<IQueryable<CommentDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CommentDb>(_commentsDb.Provider));

            _mockContext.Setup(c => c.Comments).Returns(_mockSet.Object);
            _mockRepo = new CommentRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<IEnumerable<CommentDb>, IEnumerable<CommentInfo>>(_commentsDb)).Returns(_commentsInfo);
            _service = new CommentService(_mockMapper.Object, _mockRepo);
            var comments = await _service.GetAllAsync();

            comments.Should().BeEquivalentTo(_commentsInfo);
            comments.Count().Should().Be(_commentsInfo.Count());
            comments.First().Text.Should().Be(_commentsInfo.First().Text);
        }

        [Test]
        public async Task Test_Gett_Comments_ById_Async()
        {

            _mockSet.As<IDbAsyncEnumerable<CommentDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CommentDb>(_commentsDb.GetEnumerator()));
            _mockSet.As<IQueryable<CommentDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CommentDb>(_commentsDb.Provider));

            _mockContext.Setup(c => c.Comments).Returns(_mockSet.Object);
            _mockRepo = new CommentRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CommentDb, CommentInfo>(_commentsDb.First())).Returns(_commentsInfo.First());
            _service = new CommentService(_mockMapper.Object, _mockRepo);
            var comment = await _service.GetCommentByIdAsync(_commentsDb.First().CommentId);

            comment.Should().Be(_commentsInfo.First());
            comment.Text.Should().Be("AAAAA");
        }

        [Test]
        public async Task Test_Create_Comment_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CommentDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CommentDb>(_commentsDb.GetEnumerator()));
            _mockSet.As<IQueryable<CommentDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CommentDb>(_commentsDb.Provider));

            _mockContext.Setup(c => c.Comments).Returns(_mockSet.Object);
            _mockRepo = new CommentRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CommentInfo, CommentDb>(_oneCommentInfo)).Returns(_oneCommentDb);
            _service = new CommentService(_mockMapper.Object, _mockRepo);

            var result = await _service.AddAsync(_oneCommentInfo);
            _mockSet.Verify(b => b.Add(It.IsAny<CommentDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_DeleteById_Comment_Async()
        {
            _mockSet.As<IDbAsyncEnumerable<CommentDb>>().Setup(b => b.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CommentDb>(_commentsDb.GetEnumerator()));
            _mockSet.As<IQueryable<CommentDb>>().Setup(b => b.Provider).Returns(new TestDbAsyncQueryProvider<CommentDb>(_commentsDb.Provider));

            _mockContext.Setup(c => c.Comments).Returns(_mockSet.Object);
            _mockRepo = new CommentRepository(_mockContext.Object);
            _mockMapper.Setup(m => m.Map<CommentDb, CommentInfo>(_commentsDb.First())).Returns(_commentsInfo.First());
            _service = new CommentService(_mockMapper.Object, _mockRepo);
            var result = await _service.DeleteByIdAsync(_commentsDb.First().CommentId);
            _mockSet.Verify(b => b.Remove(It.IsAny<CommentDb>()), Times.Once());
            _mockContext.Verify(b => b.SaveChangesAsync(), Times.Once());
            result.IsSuccess.Should().BeTrue();
        }
    }
}
