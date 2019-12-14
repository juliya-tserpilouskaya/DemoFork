using BulbaCourses.Analytics.BLL.Infrastructure;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.Tests
{
    [TestFixture]
    public class ValidateTests
    {
        private Validation _validation;

        [SetUp]
        public void Init()
        {
            _validation = new Validation();
        }

        [Test]
        public void ErrorNotNull()
        { 
            _validation.Errors.Should().NotBeNull();
        }

        [Test, Sequential]
        public void InitErrorBeClear(
            [Values("k1", "k2")] string key,
            [Values("v1", "v2")] string value
            )
        {
            _validation.AddError(key, value);
            _validation.Init();
            
            var expected = new ErrorContainer(new Dictionary<string, string>());
            
            _validation.Errors.Should().BeEquivalentTo(expected);
        }        

        [Test, Sequential]
        public void IsErrorBeTrue(
            [Values("k1", "k2")] string key,
            [Values("v1", "v2")] string value
            )
        {            
            _validation.AddError(key, value);
                        
            _validation.IsErrors.Should().BeTrue();
        }

        [Test, Sequential]
        public void StringIsNullBeTrue(
            [Values(null, "")] string id,
            [Values("p1", "p2")] string param,
            [Values("m1", "m2")] string message
            )
        {
            _validation.IsNull(id, param, message).Should().BeTrue();
        }

        [Test, Sequential]
        public void StringIsNullBeFalse(
            [Values("id1", "id2")] string id,
            [Values("p1", "p2")] string param,
            [Values("m1", "m2")] string message
            )
        {
            _validation.IsNull(id, param, message).Should().BeFalse();
        }

        [Test]
        public void ObjectIsNullBeTrue(
            [Values(null)] object id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsNull(id, param, message).Should().BeTrue();
        }

        [Test]
        public void ObjectIsNullBeFalse(
            [Values("id")] object id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsNull(id, param, message).Should().BeFalse();
        }

        [Test]
        public void IsEmptyBeTrue(
            [Values(true)] bool id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsEmty(id, param, message).Should().BeTrue();
        }

        [Test]
        public void IsEmptyBeFalse(
            [Values(false)] bool id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsEmty(id, param, message).Should().BeFalse();
        }

        [Test]
        public void IsZeroBeTrue(
            [Values(0)] int id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsZero(id, param, message).Should().BeTrue();
        }

        [Test]
        public void IsZeroBeFalse(
            [Values(1)] int id,
            [Values("p")] string param,
            [Values("m")] string message
            )
        {
            _validation.IsZero(id, param, message).Should().BeFalse();
        }

    }
}
