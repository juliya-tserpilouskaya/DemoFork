using BulbaCourses.Analytics.BLL.Infrastructure.Assemblies;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BulbaCourses.Analytics.Tests
{
    [TestFixture]
    public class AssemblyHelperTests
    {
        [Test]
        public void CreateInstanceCtor()
        {
            var myTestClass = AssemblyHelper.CreateInstance<MyTestClass>(01012019, "New Year");

            int expectedValueInt = 01012020;
            string expectedValueString = "New Year!";

            myTestClass.MyPropertyInt.Should().Be(expectedValueInt);
            myTestClass.MyPropertyString.Should().Contain(expectedValueString);
        }

        [Test]
        public void CreateInstanceFromTypeChild()
        {
            var myTestClass = AssemblyHelper.CreateInstance<MyTestClass>(typeof(MyChildTestClass), 01012019, "New Year");

            int expectedValueInt = 01012020;
            string expectedValueString = "New Year!";

            myTestClass.MyPropertyInt.Should().Be(expectedValueInt);
            myTestClass.MyPropertyString.Should().Contain(expectedValueString);
        }

        [Test]
        public void CreateInstanceTypeParamsFromTypeBeException()
        {
            Type type = null;
            Action action = () => { var myTestClass = AssemblyHelper.CreateInstance<MyTestClass>(type, ""); };

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void CreateInstanceTypeFromTypeBeException()
        {
            Type type = null;
            Action action = () => { var myTestClass = AssemblyHelper.CreateInstance<MyTestClass>(type); };

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void CreateInstanceTypeFromType()
        {
            var myTestClass = AssemblyHelper.CreateInstance<MyFreeTestClass>(typeof(MyFreeTestClass));

            myTestClass.Should().NotBeNull();
        }

        [Test]
        public void CreateInstance()
        {
            var myTestClass = AssemblyHelper.CreateInstance<MyFreeTestClass>();
            myTestClass.Should().NotBeNull();
        }

        [Test]
        public void LoadedAssembliesBeNotNull()
        {
            var loadedAssemblies = AssemblyHelper.LoadedAssemblies("BulbaCourses.Analytics.");

            loadedAssemblies.Should().NotBeNull();
        }

        [Test]
        public void LoadedAssembliesBeNull()
        {
            var loadedAssemblies = AssemblyHelper.LoadedAssemblies("NOTFOUND");

            loadedAssemblies.Should().BeNull();
        }

        [Test]
        public void GetInstancedObjectsBeNotNull()
        {
            var instancedObjects = AssemblyHelper.GetInstancedObjects<MyFreeTestClass>("BulbaCourses.Analytics.");

            instancedObjects.Should().NotBeNull();
        }

        [Test]
        public void LGetInstancedObjectsBeNull()
        {
            var loadedAssemblies = AssemblyHelper.GetInstancedObjects<MyFreeTestClass>("NOTFOUND");

            loadedAssemblies.Should().BeNull();
        }

        [Test]
        public void LGetInstancedObjects2BeNull()
        {
            var loadedAssemblies = AssemblyHelper.GetInstancedObjects<MyFreeTestClass>("BulbaCourses.Analytics.BLL");

            loadedAssemblies.Should().BeNull();
        }
    }

    public class MyTestClass
    {
        public MyTestClass(int v1, string v2)
        {
            MyPropertyInt = v1 + 1;
            MyPropertyString = v2 + "!";

        }

        public int MyPropertyInt { get; set; }

        public string MyPropertyString { get; set; }
    }

    public class MyChildTestClass : MyTestClass
    {
        public MyChildTestClass(int v1, string v2) : base(v1, v2)
        {

        }
    }

    public class MyFreeTestClass
    {
        public MyFreeTestClass()
        {

        }
    }
}
