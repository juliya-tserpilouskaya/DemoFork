using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Logic.Models;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Logic.AutoMapper.Profiles;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Layers.Logic.Services
{
    [TestFixture]
    public class UnitTest_Service_Test
    {
        IService_Test _service_Test;

        [OneTimeSetUp]
        public void Init()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IService_Test>().To<Service_Test>();

            kernel.Bind<DbContext>().To<DbContext_LocalDb_Test>();

            kernel.Bind<IMapper>().ToMethod(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile_DataLogicLayer>();
            })));

            _service_Test = kernel.Get<IService_Test>();
        }

        [Test]
        public void GetByIdTest()
        {
            var Test_MainInfo = _service_Test.GetById(1);

            Assert.Warn($@"{Test_MainInfo.Data.Questions_ChoosingAnswerFromList.FirstOrDefault().AnswerVariants.FirstOrDefault().AnswerText} || {Test_MainInfo.Data.Name}");            
        }

        [Test]
        public void GetByIdAsyncTest()
        {
            Task<MTest_MainInfo> Test_MainInfo = _service_Test.GetByIdAsync(1);

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


            var ResultId_1 = _service_Test.Add(TestData);

            var ResultId_1_2 = _service_Test.Add(TestData);
                     
            Assert.Warn($@"ResultId: {ResultId_1.Data.Id} || {ResultId_1_2.Data.Name}");           
        }

        [Test]
        public async Task AddTestAsync()
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

            var HasAdd = await _service_Test.AddAsync(TestData);

            Assert.Warn($@"ResultId: {HasAdd.IsSuccess}");
        }

        [Test]
        public void DeleteById()
        {
            var Test_MainInfo =  _service_Test.DeleteById(1);

            Assert.Warn($@"{Test_MainInfo.IsSuccess}");
        }

        [Test]
        public async Task DeleteByIdAsync()
        {
            var Test_MainInfo = await _service_Test.DeleteByIdAsync(1);

            Assert.Warn($@"{Test_MainInfo.IsSuccess}");
        }

        [Test]
        public void Update()
        {
            MTest_MainInfo TestData =
                new MTest_MainInfo()
                {
                    Name = "Test_Name_3",
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

            var Test_MainInfo = _service_Test.Update(TestData);

            Assert.Warn($@"{Test_MainInfo.Data.Name}");
        }

        [Test]
        public async Task UpdateAsync()
        {
            MTest_MainInfo TestData =
                new MTest_MainInfo()
                {
                    Id = 1,
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


            var Test_MainInfo = await _service_Test.UpdateAsync(TestData);

            Assert.Warn($@"{Test_MainInfo.Data.Name}");
        }
    }
}
