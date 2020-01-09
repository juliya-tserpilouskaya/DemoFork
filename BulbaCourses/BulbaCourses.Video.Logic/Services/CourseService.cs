using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseInfo> GetAll()
        {
            var courses = _courseRepository.GetAll();
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
            return result;
        }

        public void Delete(CourseInfo course)
        {
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            _courseRepository.Remove(courseDb);
        }

        public void DeleteById(string courseId)
        {
            var course = _courseRepository.GetById(courseId);
            _courseRepository.Remove(course);
        }

        public void Update(CourseInfo course)
        {
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            _courseRepository.Update(courseDb);
        }

        public void AddCourse(CourseInfo course)
        {
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            _courseRepository.Add(courseDb);
        }



        public void AddDiscription(string courseId, string description)
        {
            var course = _courseRepository.GetById(courseId);
            course.Description = description;
            _courseRepository.Update(course);

        }

        public void AddVideoToCourse(string courseId, VideoMaterialInfo video)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            var courseVideos = _courseRepository.GetById(courseId).Videos;
            courseVideos.Add(videoDb);
        }

        public void AddTagToCourse(string courseId, TagInfo tag)
        {
            var tagDb = _mapper.Map<TagInfo, TagDb>(tag);
            var courseTags = _courseRepository.GetById(courseId).Tags;
            courseTags.Add(tagDb);
        }

        public CourseInfo GetCourseById(string courseId)
        {
            var course = _courseRepository.GetById(courseId);
            var courseInfo = _mapper.Map<CourseDb, CourseInfo>(course);
            return courseInfo;
        }

        public CourseInfo GetCourseByName(string courseName)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(c => c.Name.Equals(courseName));
            var courseInfo = _mapper.Map<CourseDb, CourseInfo>(course);
            return courseInfo;
        }

        public int GetCourseLevel(string courseId)
        {
            var result = _courseRepository.GetById(courseId).Level;
            return result;
        }

        public IEnumerable<TagInfo> GetTags(string courseId)
        {
            var courseTags = _courseRepository.GetById(courseId).Tags.ToList().AsReadOnly();
            var courseTagsInfo = _mapper.Map<IEnumerable<TagDb>, IEnumerable<TagInfo>>(courseTags);
            return courseTagsInfo;
        }

        public VideoMaterialInfo GetVideoByOrder(string courseId, int videoOrder)
        {
            var course = _courseRepository.GetById(courseId);
            var videoDb = course.Videos.FirstOrDefault(c => c.Order == videoOrder);
            var result = _mapper.Map<VideoMaterialDb, VideoMaterialInfo>(videoDb);
            return result;
        }

        public void UpdateCourseLevel(string courseId, int level)
        {
            var course = _courseRepository.GetById(courseId);
            course.Level = level;
            _courseRepository.Update(course);
        }

        public IEnumerable<VideoMaterialInfo> GetCourseVideos(string courseId)
        {
            var course = _courseRepository.GetById(courseId);
            var videoListDb = course.Videos.ToList().AsReadOnly();
            var result = _mapper.Map<IEnumerable<VideoMaterialDb>, IEnumerable<VideoMaterialInfo>>(videoListDb);
            return result;
        }


        public async Task<IEnumerable<CourseInfo>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
            return result;
        }

        public async Task<CourseInfo> GetCourseByIdAsync(string courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            var courseInfo = _mapper.Map<CourseDb, CourseInfo>(course);
            return courseInfo;
        }

        public async Task<IEnumerable<CourseInfo>> GetListByTagAsync(TagInfo tag)
        {
            var tagDb = _mapper.Map<TagInfo, TagDb>(tag);
            var courses = await _courseRepository.GetAllAsync();
            courses = courses.Where(c => c.Tags.Contains(tagDb));
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
            return result;
        }

        public async Task<Result<CourseInfo>> AddCourseAsync(CourseInfo course)
        {
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            try
            {
                await _courseRepository.AddAsync(courseDb);
                return Result<CourseInfo>.Ok(_mapper.Map<CourseInfo>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Cannot save course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Cannot save course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Invalid course. {e.Message}");
            }
        }

        public async Task<Result<CourseInfo>> UpdateAsync(CourseInfo course)
        {
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            try
            {
                await _courseRepository.UpdateAsync(courseDb);
                return Result<CourseInfo>.Ok(_mapper.Map<CourseInfo>(courseDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Cannot update course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Cannot update course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseInfo>)Result.Fail($"Invalid course. {e.Message}");
            }
        }

        public Task<Result> DeleteByIdAsync(string id)
        {
            _courseRepository.RemoveAsyncById(id);
            return Task.FromResult(Result.Ok());
        }

        public async Task<bool> ExistNameAsync(string courseName)
        {
            return await _courseRepository.IsNameExistAsync(courseName);
        }

        public Task<CourseInfo> GetCourseByNameAsync(string courseName)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RateCourse(CourseInfo course, int Assessment)
        {
            throw new NotImplementedException();
        }

        public Task<Result> AddVideoAsync(CourseInfo course, VideoMaterialInfo video)
        {
            throw new NotImplementedException();
        }

        public Task<Result> AddTagAsync(CourseInfo course, TagInfo tag)
        {
            throw new NotImplementedException();
        }

        public Task<Result> ChangeLevel(CourseInfo course, int level)
        {
            throw new NotImplementedException();
        }
    }
}
