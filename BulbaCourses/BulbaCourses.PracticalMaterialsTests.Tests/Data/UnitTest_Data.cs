using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using NUnit.Framework;
using System.Linq;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Data
{
    [TestFixture]
    public class UnitTest_Data
    {
        [OneTimeSetUp]
        public void Init()
        {
            
        }

        [Test]
        public void TestMethod1()
        {
            using (DbContext_Test cc = new DbContext_Test())
            {
                foreach (var Row_1 in cc.Test_MainInfo.Select(c => c.Question_ChoosingAnswerFromList))
                {
                    foreach(var Row_2 in Row_1)
                    {
                        Assert.Warn($@"{Row_2.QuestionText} || {Row_2.SortKey}");
                    }                    
                }
            }
        }
    }
}
