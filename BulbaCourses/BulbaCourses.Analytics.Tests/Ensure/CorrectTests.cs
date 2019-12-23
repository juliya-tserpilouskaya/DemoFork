using FluentAssertions;
using NUnit.Framework;

namespace BulbaCourses.Analytics.BLL.Ensure.Tests
{
    [TestFixture()]
    public class CorrectTests
    {
        [Test()]
        public void SpaceFixTestBeNull()
        {
            string testString = null;
            var result = testString.SpaceFix();

            result.Should().BeNull();
        }

        [Test()]
        public void SpaceFixTestBeEmpty()
        {
            string testString = "";
            var result = testString.SpaceFix();

            result.Should().BeEmpty();
        }

        [Test()]
        public void SpaceFixTestBeFixString()
        {
            string testString = "   sfg fg    dfg  fg   f ";
            var result = testString.SpaceFix();

            var expected = "sfg fg dfg fg f";

            result.Should().BeEquivalentTo(expected);
        }
    }
}