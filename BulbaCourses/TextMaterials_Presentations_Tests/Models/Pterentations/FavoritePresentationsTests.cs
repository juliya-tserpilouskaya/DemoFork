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

namespace TextMaterials_Presentations_Tests.Models.Pterentations
{
    [TestFixture]
    public class FavoritePresentationsTests
    {
        List<Presentation> _fakePresentations;
        Student _student;

        FavoritePresentationsService _favoritePresentationsService = new FavoritePresentationsService();

        Faker<Presentation> _faker = new Faker<Presentation>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.IsAccessible, y => y.Random.Bool())
                                                   .RuleFor(x => x.CourseId, y => y.Random.Byte(0, 250).ToString());

        [SetUp]
        public void ListGenerator() //if everyone test is failed - check the Add method
        {
            _student = new Student();
            _student.FavoritePresentations = new List<Presentation>();

            _fakePresentations = _faker.Generate(5);

            foreach (var item in _fakePresentations)
            {
                _favoritePresentationsService.Add(_student, item);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Presentation> presentations = _faker.Generate(5);

            foreach (var item in presentations)
            {
                _favoritePresentationsService.Add(_student, item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            _favoritePresentationsService.GetAll(_student).Should().BeEquivalentTo(_fakePresentations);
        }

        [Test]
        public void GetById_Test()
        {
            _favoritePresentationsService.GetById(_student, _fakePresentations.First<Presentation>().Id).Should().BeEquivalentTo(_fakePresentations.First<Presentation>());
        }

        [Test]
        public void DeleteById_Test()
        {
            _favoritePresentationsService.DeleteById(_student, _fakePresentations.First<Presentation>().Id).Should().BeTrue();
            _favoritePresentationsService.GetById(_student, _fakePresentations.First<Presentation>().Id).Should().BeNull();
        }
    }
}
