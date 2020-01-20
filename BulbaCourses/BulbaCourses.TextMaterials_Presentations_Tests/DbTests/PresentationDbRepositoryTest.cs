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
    public class PresentationDbRepositoryTest
    {
        Mock<PresentationsContext> _mockContext;

        List<PresentationDB> _fakePresentations;

        Faker<PresentationDB> _fake = new Faker<PresentationDB>().RuleFor(x => x.Title, y => y.Name.JobTitle())
                                                                             .RuleFor(x => x.DateUpdate, DateTime.Now)
                                                                             .RuleFor(x => x.IsAccessible, y => y.Random.Bool());

        [OneTimeSetUp]
        public void Starter()
        {
            _mockContext = new Mock<PresentationsContext>();
            _fakePresentations = _fake.Generate(3);

            _mockContext.Setup(_ => _.Presentations).Returns(_fakePresentations);
        }

        [Test]
        public void AddPresentationTestAsync()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                List<PresentationDB> forAdd = _fake.Generate(1);
                var presentation = forAdd.FirstOrDefault();

                Assert.IsFalse(_fakePresentations.Contains(presentation));

                _mockContext.Setup(_ => _.Presentations.Add(It.IsAny<PresentationDB>()))
                            .Returns((PresentationDB c) =>
                            {
                                _fakePresentations.Add(c);
                                return c;
                            });

                uow.Presentations.Add(presentation);

                _mockContext.Verify(_ => _.Presentations.Add(It.IsAny<PresentationDB>()), Times.Once());
                Assert.IsTrue(_fakePresentations.Contains(presentation));
            }
        }

        [Test]
        public async Task GetPresentationByIdAsyncTest()
        {

            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var presentation = _fakePresentations.FirstOrDefault();

                var gettedPresentation = await uow.Presentations.GetByIdAsync(presentation.Id);

                presentation.Should().BeEquivalentTo(gettedPresentation);
            }
        }

        [Test]
        public async Task GetAllPresentationAsyncTest()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var presentations = await uow.Presentations.GetAllAsync();

                Assert.AreEqual(_fakePresentations, presentations);
            }
        }
    }
}
