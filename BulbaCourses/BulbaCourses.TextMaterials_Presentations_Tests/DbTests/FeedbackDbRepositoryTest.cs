using BulbaCourses.TextMaterials_Presentations.Data;
using Presentations.Logic.Repositories;
using Presentations.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq.EntityFramework.Helpers;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;
using Moq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TextMaterials_Presentations_Tests.DbTests
{
    [TestFixture]
    public class FeedbackDbRepositoryTest
    {
        Mock<PresentationsContext> _mockContext;

        List<FeedbackDB> _fakeFeedbacks;

        Faker<FeedbackDB> _fake = new Faker<FeedbackDB>().RuleFor(x => x.Text, y => y.Name.JobTitle())
                                                                 .RuleFor(x => x.Date, DateTime.Now);

        [OneTimeSetUp]
        public void Starter()
        {
            _mockContext = new Mock<PresentationsContext>();
            _fakeFeedbacks = _fake.Generate(3);

            _mockContext.Setup(_ => _.Feedbacks).Returns(_fakeFeedbacks);
        }

        [Test]
        public void AddFeedbackTestAsync()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                List<FeedbackDB> forAdd = _fake.Generate(1);
                var feedback = forAdd.FirstOrDefault();

                Assert.IsFalse(_fakeFeedbacks.Contains(feedback));

                _mockContext.Setup(_ => _.Feedbacks.Add(It.IsAny<FeedbackDB>()))
                            .Returns((FeedbackDB c) =>
                            {
                                _fakeFeedbacks.Add(c);
                                return c;
                            });

                uow.Feedbacks.Add(feedback);

                _mockContext.Verify(_ => _.Feedbacks.Add(It.IsAny<FeedbackDB>()), Times.Once());
                Assert.IsTrue(_fakeFeedbacks.Contains(feedback));
            }
        }

        [Test]
        public async Task GetFeedbackByIdAsyncTest()
        {

            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var feedback = _fakeFeedbacks.FirstOrDefault();

                var gettedFeedback = await uow.Feedbacks.GetByIdAsync(feedback.Id);

                feedback.Should().BeEquivalentTo(gettedFeedback);
            }
        }

        [Test]
        public async Task GetAllFeedbackAsyncTest()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var feedbacks = await uow.Feedbacks.GetAllAsync();

                Assert.AreEqual(_fakeFeedbacks, feedbacks);
            }
        }
    }
}
