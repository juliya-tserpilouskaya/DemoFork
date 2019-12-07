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
    public class FeedbackServiceTest
    {
        List<Feedback> _fakeFeedbacks;
        Presentation _presentation;
        User _user;

        FeedbackService _feedbackService = new FeedbackService();

        Faker<Feedback> _faker = new Faker<Feedback>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString());

        [SetUp]
        public void ListGenerator() //if everyone test are failed - check the Add method
        {
            _presentation = new Presentation { Id = "1" };
            _user = new User { Id = "1"};

            _presentation.Feedback = new List<Feedback>();

            _fakeFeedbacks = _faker.Generate(5);

            foreach (var item in _fakeFeedbacks)
            {
                _feedbackService.Add(item, _presentation, _user);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Feedback> feedbacks = _faker.Generate(5);

            foreach (var item in feedbacks)
            {
                _feedbackService.Add(item, _presentation, _user).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            _feedbackService.GetAll(_presentation).Should().BeEquivalentTo(_fakeFeedbacks);
        }

        [Test]
        public void GetById_Test()
        {
            _feedbackService.GetById(_presentation, _fakeFeedbacks.First<Feedback>().Id).Should().BeEquivalentTo(_fakeFeedbacks.First<Feedback>());
        }

        [Test]
        public void DeleteById_Test()
        {
            _feedbackService.DeleteById(_presentation, _fakeFeedbacks.First<Feedback>().Id).Should().BeTrue();
            _feedbackService.GetById(_presentation, _fakeFeedbacks.First<Feedback>().Id).Should().BeNull();
        }
    }
}
