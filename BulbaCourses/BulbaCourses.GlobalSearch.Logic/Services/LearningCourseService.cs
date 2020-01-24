using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
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
        IMapper _mapper;
        ISearchService _lucene;

        public LearningCourseService(IMapper mapper, ICourseDbService learningCourseDb)
        {
            _learningCourseDb = learningCourseDb;
            _mapper = mapper;
        }

        public LearningCourseService(IMapper mapper, ICourseDbService learningCourseDb, ISearchService lucene)
        {
            _learningCourseDb = learningCourseDb;
            _mapper = mapper;
            _lucene = lucene;
        }

        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetAllCourses()
        {
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetAllCourses());
        }

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetAllCoursesAsync()
        {
            var data = await _learningCourseDb.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public LearningCourseDTO GetById(string id)
        {
            var course = _learningCourseDb.GetById(id);
            return _mapper.Map<CourseDB, LearningCourseDTO>(course);
        }

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<LearningCourseDTO> GetByIdAsync(string id)
        {
            var course = await _learningCourseDb.GetByIdAsync(id);
            return _mapper.Map<CourseDB, LearningCourseDTO>(course);
        }

        /// <summary>
        /// Returns learning course by category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetByCategory(int category)
        {
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByCategory(category));
        }

        /// <summary>
        /// Returns learning course by category asynchronously
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetByCategoryAsync(int category)
        {
            var data = await _learningCourseDb.GetByCategoryAsync(category);
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by author
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetByAuthorId(int id)
        {
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetByAuthorId(id));
        }

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetByAuthorIdAsync(int id)
        {
            var data = await _learningCourseDb.GetByAuthorIdAsync(id);
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course materials
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseItemDTO> GetLearningItemsByCourseId(string id)
        {
            return _mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItemDTO>>(_learningCourseDb.GetLearningItemsByCourseId(id));
        }

        /// <summary>
        /// Returns learning course materials asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseItemDTO>> GetLearningItemsByCourseIdAsync(string id)
        {
            var data = await _learningCourseDb.GetLearningItemsByCourseIdAsync(id);
            return _mapper.Map<IEnumerable<CourseItemDB>, List<LearningCourseItemDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by complexity
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity)
        {    

            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByComplexity(complexity));
        }

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByComplexityAsync(string complexity)
        {
            var data = await _learningCourseDb.GetCourseByComplexityAsync(complexity);
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Returns learning course by language
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang)
        {
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(_learningCourseDb.GetCourseByLanguage(lang));
        }

        /// <summary>
        /// Returns learning course by language asynchronously
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public async Task<IEnumerable<LearningCourseDTO>> GetCourseByLanguageAsync(string lang)
        {
            var data = await _learningCourseDb.GetCourseByLanguageAsync(lang);
            return _mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);
        }

        /// <summary>
        /// Updates and index course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public LearningCourseDTO Update(LearningCourseDTO course)
        {
            var data = _learningCourseDb.Update(_mapper.Map<LearningCourseDTO, CourseDB>(course));
            //_lucene.IndexCourse(course);
            return _mapper.Map<CourseDB, LearningCourseDTO>(data);
        }

        /// <summary>
        /// Updates and index course data async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public async Task<Result<LearningCourseDTO>> UpdateAsync(LearningCourseDTO course)
        {
            var courseDb = _mapper.Map<LearningCourseDTO, CourseDB>(course);

            var result = await _learningCourseDb.UpdateAsync(courseDb);
            //_lucene.IndexCourse(course);
            return result.IsSuccess ? Result<LearningCourseDTO>.Ok(_mapper.Map<LearningCourseDTO>(result.Data))
                : Result<LearningCourseDTO>.Fail<LearningCourseDTO>(result.Message);
        }


        /// <summary>
        /// Updates course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public LearningCourseDTO UpdateNoIndex(LearningCourseDTO course)
        {
            var data = _learningCourseDb.Update(_mapper.Map<LearningCourseDTO, CourseDB>(course));
            return _mapper.Map<CourseDB, LearningCourseDTO>(data);
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
            LearningCourseDTO LearningCourse = mapper.Map<CourseDB, LearningCourseDTO>(data);
            //_lucene.IndexCourse(LearningCourse);
            return LearningCourse;
        }

        /// <summary>
        /// Creates learning course async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public async Task<Result<LearningCourseDTO>> AddAsync(LearningCourseDTO course)
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

            var courseDb = mapper.Map<LearningCourseDTO, CourseDB>(course);
            var result = await _learningCourseDb.AddAsync(courseDb);
            //_lucene.IndexCourse(course);

            return result.IsSuccess ? Result<LearningCourseDTO>.Ok(mapper.Map<LearningCourseDTO>(result.Data))
                : Result<LearningCourseDTO>.Fail<LearningCourseDTO>(result.Message);
        }

        /// <summary>
        /// Creates learning course
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public LearningCourseDTO AddNoIndex(LearningCourseDTO course)
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
            LearningCourseDTO LearningCourse = mapper.Map<CourseDB, LearningCourseDTO>(data);
            return LearningCourse;
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

        /// <summary>
        /// Deletes course from database async
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public Task<Result> DeleteByIdAsync(string id)
        {
            _learningCourseDb.DeleteByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }
    }
}