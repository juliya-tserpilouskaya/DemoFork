using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    public class LearningCourseService : ILearningCourseService
    {
        ICourseDbService _learningCourseDb;

        public LearningCourseService(ICourseDbService learningCourseDb)
        {
            _learningCourseDb = learningCourseDb;
        }
        public IEnumerable<LearningCourseDTO> GetAllCourses()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetAllCourses());
        }

        public async Task<IEnumerable<LearningCourseDTO>> GetAllCoursesAsync()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
            }).CreateMapper();
            var data = await _learningCourseDb.GetAllCoursesAsync();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        public LearningCourseDTO GetById(string id)
        {
            var mapper = new MapperConfiguration(cfg => 
                cfg.CreateMap<CourseItemDB, LearningCourseItem>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name))
                    .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(x => x.Description, opt => opt.MapFrom(c => c.Description))
                ).CreateMapper();
            var course = _learningCourseDb.GetById(id);
            return new LearningCourseDTO {
                Id = course.Id,
                AuthorId = course.AuthorDBId,
                Category = course.CourseCategoryDBId,
                Complexity = course.Complexity,
                Cost = course.Cost,
                Description = course.Description,
                Items = mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItem>>(course.Items),
                Language = course.Language,
                Name = course.Name
            };
        }

        public async Task<LearningCourseDTO> GetByIdAsync(string id)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseItemDB, LearningCourseItem>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name))
                    .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(x => x.Description, opt => opt.MapFrom(c => c.Description))
                ).CreateMapper();
            var course = await _learningCourseDb.GetByIdAsync(id);
            return new LearningCourseDTO
            {
                Id = course.Id,
                AuthorId = course.AuthorDBId,
                Category = course.CourseCategoryDBId,
                Complexity = course.Complexity,
                Cost = course.Cost,
                Description = course.Description,
                //ISSUE: HOW TO GET ITEMS?
                Items = mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItem>>(course.Items),
                Language = course.Language,
                Name = course.Name
            };
        }

        public IEnumerable<LearningCourseDTO> GetByCategory(int category)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByCategory(category));
        }

        public async Task<IEnumerable<LearningCourseDTO>> GetByCategoryAsync(int category)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetByCategoryAsync(category);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        public IEnumerable<LearningCourseDTO> GetByAuthorId(int id)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByAuthorId(id));
        }

        public async Task<IEnumerable<LearningCourseDTO>> GetByAuthorIdAsync(int id)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetByAuthorIdAsync(id);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        public IEnumerable<LearningCourseItemDTO> GetLearningItemsByCourseId(string id)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name))
                    .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(x => x.Description, opt => opt.MapFrom(c => c.Description))
                ).CreateMapper();
            return mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItemDTO>>(_learningCourseDb.GetLearningItemsByCourseId(id));
        }

        public async Task<IEnumerable<LearningCourseItemDTO>> GetLearningItemsByCourseIdAsync(string id)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name))
                    .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(x => x.Description, opt => opt.MapFrom(c => c.Description))
                ).CreateMapper();
            var data = await _learningCourseDb.GetLearningItemsByCourseIdAsync(id);
            return mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItemDTO>>(data);
        }

        public IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity)
        {    
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByComplexity(complexity));
        }
        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByComplexityAsync(string complexity)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetCourseByComplexityAsync(complexity);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        public IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByLanguage(lang));
        }


        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByLanguageAsync(string lang)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetCourseByLanguageAsync(lang);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }
    }
}
