using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;

namespace BulbaCourses.PracticalMaterialsTests.Logic.AutoMap
{    
    public class AutoMapperProfile_Logic : Profile
    {
        public AutoMapperProfile_Logic()
        {
            // ----------- Test
            CreateMap<MTest_MainInfo, MTest_MainInfoDb>().ReverseMap();

            // ----------- Question

            CreateMap<MQuestion_ChoosingAnswerFromList, MQuestion_ChoosingAnswerFromListDb>().ReverseMap();
            CreateMap<MQuestion_SetIntoMissingElements, MQuestion_SetIntoMissingElementsDb>().ReverseMap();
            CreateMap<MQuestion_SetOrder, MQuestion_SetOrderDb>().ReverseMap();

            // ----------- AnswerVariant

            CreateMap<MAnswerVariant_ChoosingAnswerFromList, MAnswerVariant_ChoosingAnswerFromListDb>().ReverseMap();
            CreateMap<MQuestion_SetIntoMissingElements, MQuestion_SetIntoMissingElementsDb>().ReverseMap();
            CreateMap<MAnswerVariant_SetOrder, MAnswerVariant_SetOrderDb>().ReverseMap();
        }
    }
}
