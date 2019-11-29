using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;

namespace TextMaterials_Presentations_Tests.Models.Pterentations
{
    [TestFixture]
    public class PresentationsBaseTests
    {
        Faker<Presentation> _faker = new Faker<Presentation>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.IsAccessible, y => y.Random.Bool())
                                                   .RuleFor(x => x.IsFavorite, y => y.Random.Bool())
                                                   .RuleFor(x => x.IsViewed, y => y.Random.Bool())
                                                   .RuleFor(x => x.Title, y => y.Name.JobTitle());
        List<Presentation> _fakePresentations;

        [SetUp]
        public void ListGenerator() //if everyone test is failed - check the Add method
        {
            _fakePresentations = _faker.Generate(5);

            foreach (var item in _fakePresentations)
            {
                PresentationsBase.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakePresentations)
            {
                PresentationsBase.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Presentation> presentations = _faker.Generate(5);

            foreach (var item in presentations)
            {
                PresentationsBase.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            PresentationsBase.GetAll().Should().BeEquivalentTo(_fakePresentations);
        }

        [Test]
        public void GetById_Test()
        {
            PresentationsBase.GetById(_fakePresentations.First<Presentation>().Id).Should().BeEquivalentTo(_fakePresentations.First<Presentation>());
        }

        [Test]
        public void Update_Test()
        {
            Presentation presentationForUpdate = new Presentation()
            {
                Id = _fakePresentations.First<Presentation>().Id,
                Title = "1",
                IsAccessible = true,
                IsViewed = true,
                IsFavorite = true
            };

            Presentation presentationBeforeUpdate = PresentationsBase.GetById(_fakePresentations.First<Presentation>().Id);
            Presentation presentationAfterUpdate = PresentationsBase.Update(presentationForUpdate);

            presentationAfterUpdate.Title.Should().BeEquivalentTo(presentationForUpdate.Title);
        }

        [Test]
        public void DeleteById_Test()
        {
            PresentationsBase.DeleteById(_fakePresentations.First<Presentation>().Id).Should().BeTrue();
            PresentationsBase.GetById(_fakePresentations.First<Presentation>().Id).Should().BeNull();
        }
    }
}
