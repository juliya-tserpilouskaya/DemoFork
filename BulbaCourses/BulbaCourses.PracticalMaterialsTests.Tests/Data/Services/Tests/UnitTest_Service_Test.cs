using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Data.Services.Tests
{
    [TestFixture]
    public class UnitTest_Service_Test
    {
        IService_Test _serviceTest;

        [OneTimeSetUp]
        public void Init()
        {
            _serviceTest = 
                new Service_Test(new DbContext_Test(), new Mapper(
                    new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MTest_MainInfo, MTest_MainInfoDb>().ReverseMap();
                        cfg.CreateMap<MQuestion_ChoosingAnswerFromList, MQuestion_ChoosingAnswerFromListDb>().ReverseMap();
                        cfg.CreateMap<MQuestion_SetIntoMissingElements, MQuestion_SetIntoMissingElementsDb>().ReverseMap();
                        cfg.CreateMap<MQuestion_SetOrder, MQuestion_SetOrderDb>().ReverseMap();                        
                        cfg.CreateMap<MAnswerVariant_ChoosingAnswerFromList, MAnswerVariant_ChoosingAnswerFromListDb>().ReverseMap();
                        cfg.CreateMap<MQuestion_SetIntoMissingElements, MQuestion_SetIntoMissingElementsDb>().ReverseMap();
                        cfg.CreateMap<MAnswerVariant_SetOrder, MAnswerVariant_SetOrderDb>().ReverseMap();                        
                    })));
        }

        [Test]
        public void GetByIdTest()
        {
            MTest_MainInfo Test_MainInfo = _serviceTest.GetById(1);

            Assert.Warn($@"{Test_MainInfo.Questions_ChoosingAnswerFromList.FirstOrDefault().AnswerVariants.FirstOrDefault().AnswerText} || {Test_MainInfo.Name}");
        }

        [Test]
        public void GetByIdAsyncTest()
        {
            Task<MTest_MainInfo> Test_MainInfo = _serviceTest.GetByIdAsync(1);

            Assert.Warn($@"{Test_MainInfo.Result.Questions_ChoosingAnswerFromList.FirstOrDefault().AnswerVariants.FirstOrDefault().AnswerText} || {Test_MainInfo.Result.Name}");             
        }

        [Test]
        public void AddTest()
        {
            MTest_MainInfo TestData =
                new MTest_MainInfo()
                {
                    Name = "Test_Name_2",
                    Questions_ChoosingAnswerFromList =
                        new List<MQuestion_ChoosingAnswerFromList>()
                        {
                                new MQuestion_ChoosingAnswerFromList()
                                {
                                    QuestionText = "Question_ChoosingAnswerFromListDb_Text_1",
                                    SortKey = 1,
                                    AnswerVariants =
                                    new List<MAnswerVariant_ChoosingAnswerFromList>()
                                    {
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            IsCorrectAnswer = true
                                        }
                                    }
                                }
                        },
                    Questions_SetIntoMissingElements =
                        new List<MQuestion_SetIntoMissingElements>()
                        {
                            new MQuestion_SetIntoMissingElements()
                            {
                                QuestionText = "Question_SetIntoMissingElementsDb_Text_1",
                                SortKey = 2
                            }
                        },
                    Questions_SetOrder =
                        new List<MQuestion_SetOrder>()
                        {
                                new MQuestion_SetOrder()
                                {
                                    QuestionText = "QuestionText_1",
                                    SortKey = 3,
                                    AnswerVariants =
                                    new List<MAnswerVariant_SetOrder>()
                                    {
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            CorrectOrderKey = 1
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            CorrectOrderKey = 2
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            CorrectOrderKey = 3
                                        }
                                    }
                                }
                        }
                };
                

            int ResultId_1 = _serviceTest.Add(TestData);

            int ResultId_1_2 = _serviceTest.Add(TestData);

            Assert.Warn($@"ResultId: {ResultId_1} || {ResultId_1_2}");
        }        
    }
}
