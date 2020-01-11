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

        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetAllCourses()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetAllCourses());
        }

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetAllCoursesAsync()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>();
            }).CreateMapper();
            var data = await _learningCourseDb.GetAllCoursesAsync();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public LearningCourseDTO GetById(string id)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>();
            }).CreateMapper();
            var course = _learningCourseDb.GetById(id);
            return mapper.Map<CourseDB, LearningCourseDTO>(course);
        }

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<LearningCourseDTO> GetByIdAsync(string id)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>();
            }).CreateMapper();
            var course = await _learningCourseDb.GetByIdAsync(id);
            return mapper.Map<CourseDB, LearningCourseDTO>(course);
        }

        /// <summary>
        /// Returns learning course by category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetByCategory(int category)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByCategory(category));
        }

        /// <summary>
        /// Returns learning course by category asynchronously
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetByCategoryAsync(int category)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetByCategoryAsync(category);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by author
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetByAuthorId(int id)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByAuthorId(id));
        }

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetByAuthorIdAsync(int id)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>();
            }).CreateMapper();
            var data = await _learningCourseDb.GetByAuthorIdAsync(id);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course materials
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns learning course materials asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns learning course by complexity
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity)
        {    
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByComplexity(complexity));
        }

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByComplexityAsync(string complexity)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetCourseByComplexityAsync(complexity);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by language
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByLanguage(lang));
        }

        /// <summary>
        /// Returns learning course by language asynchronously
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByLanguageAsync(string lang)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CourseDB, LearningCourseDTO>()).CreateMapper();
            var data = await _learningCourseDb.GetCourseByLanguageAsync(lang);
            return mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Updates course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public LearningCourseDTO Update(LearningCourseDTO course)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>().ReverseMap();
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>().ReverseMap();
            }).CreateMapper();
            var data = _learningCourseDb.Update(mapper.Map<LearningCourseDTO, CourseDB>(course));
            return mapper.Map<CourseDB, LearningCourseDTO>(data);
        }

        /// <summary>
        /// Creates learning course
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public LearningCourseDTO Add(LearningCourseDTO course)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseDB, LearningCourseDTO>()
                    .ForMember(x => x.AuthorId, opt => opt.MapFrom(c => c.AuthorDBId))
                    .ForMember(x => x.Category, opt => opt.MapFrom(c => c.CourseCategoryDBId))
                    .ReverseMap()
                    .ForPath(x => x.AuthorDBId, opt => opt.MapFrom(c => c.AuthorId))
                    .ForPath(x => x.CourseCategoryDBId, opt => opt.MapFrom(c => c.Category));
                cfg.CreateMap<CourseItemDB, LearningCourseItemDTO>().ReverseMap();
            }).CreateMapper();
            var data = _learningCourseDb.Add(mapper.Map<LearningCourseDTO, CourseDB>(course));
            return mapper.Map<CourseDB, LearningCourseDTO>(data);
        }

        /// <summary>
        /// Deletes course from database
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public bool DeleteById(string id)
        {
            return _learningCourseDb.DeleteById(id);
        }
    }
}
