using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace TextMaterials_Presentations_Tests.Models.CourseAndPresentations.Pterentations
{
    [TestFixture]
    public class PresentationsBaseServiceTest
    {
        PresentationsBaseService _presentationsBaseService = new PresentationsBaseService();
        List<Presentation> _fakePresentations;

        Faker<Presentation> _faker = new Faker<Presentation>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.IsAccessible, y => y.Random.Bool())
                                                   .RuleFor(x => x.CourseId, y => y.Random.Byte(0, 250).ToString());

        [SetUp]
        public void ListGenerator() //if everyone test are failed - check the Add method
        {
            _fakePresentations = _faker.Generate(5);

            foreach (var item in _fakePresentations)
            {
                _presentationsBaseService.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakePresentations)
            {
                _presentationsBaseService.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Presentation> presentations = _faker.Generate(5);

            foreach (var item in presentations)
            {
                _presentationsBaseService.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            _presentationsBaseService.GetAll().Should().BeEquivalentTo(_fakePresentations);
        }

        [Test]
        public void GetById_Test()
        {
            _presentationsBaseService.GetById(_fakePresentations.First<Presentation>().Id).Should().BeEquivalentTo(_fakePresentations.First<Presentation>());
        }

        [Test]
        public void Update_Test()
        {
            Presentation presentationForUpdate = new Presentation()
            {
                Id = _fakePresentations.First<Presentation>().Id,
                Title = "1",
                IsAccessible = true,
            };

            Presentation presentationAfterUpdate = _presentationsBaseService.Update(presentationForUpdate);

            presentationAfterUpdate.Title.Should().BeEquivalentTo(presentationForUpdate.Title);
        }

        [Test]
        public void DeleteById_Test()
        {
            _presentationsBaseService.DeleteById(_fakePresentations.First<Presentation>().Id).Should().BeTrue();
            _presentationsBaseService.GetById(_fakePresentations.First<Presentation>().Id).Should().BeNull();
        }
    }
}
