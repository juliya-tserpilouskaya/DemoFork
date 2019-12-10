using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void AddCourse(CourseInfo course)
        {
            var courseDb = mapper.Map<CourseInfo, CourseDb>(course);
            courseRepository.Add(courseDb);
        }

        public void AddDiscription(string courseId, string description)
        {
            var course = courseRepository.GetById(courseId);
            course.Description = description;
            courseRepository.Update(course);

        }

        public void AddVideoToCourse(string courseId, VideoMaterialInfo video)
        {
            var videoDb = mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            var courseVideos = courseRepository.GetById(courseId).Videos;
            courseVideos.Add(videoDb);
        }

        public void AddTagToCourse(string courseId, TagInfo tag)
        {
            var tagDb = mapper.Map<TagInfo, TagDb>(tag);
            var courseTags = courseRepository.GetById(courseId).Tags;
            courseTags.Add(tagDb);
        }

        public CourseInfo GetCourseById(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            var courseInfo = mapper.Map<CourseDb, CourseInfo>(course);
            return courseInfo;
        }

        public CourseInfo GetCourseByName(string courseName)
        {
            var course = courseRepository.GetAll().FirstOrDefault(c => c.Name.Equals(courseName));
            var courseInfo = mapper.Map<CourseDb, CourseInfo>(course);
            return courseInfo;
        }

        public IEnumerable<CourseInfo> GetAll()
        {
            var courses = courseRepository.GetAll();
            var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
            return result;
        }

        public void Delete(CourseInfo course)
        {
            var courseDb = mapper.Map<CourseInfo, CourseDb>(course);
            courseRepository.Remove(courseDb);
        }

        public void DeleteById(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            courseRepository.Remove(course);
        }

        public int GetCourseLevel(string courseId)
        {
            var result = courseRepository.GetById(courseId).Level;
            return result;
        }

        public IEnumerable<TagInfo> GetTags(string courseId)
        {
            var courseTags = courseRepository.GetById(courseId).Tags.ToList().AsReadOnly();
            var courseTagsInfo = mapper.Map<IEnumerable<TagDb>, IEnumerable<TagInfo>>(courseTags);
            return courseTagsInfo;
        }

        public VideoMaterialInfo GetVideoByOrder(string courseId, int videoOrder)
        {
            var course = courseRepository.GetById(courseId);
            var videoDb = course.Videos.FirstOrDefault(c => c.Order == videoOrder);
            var result = mapper.Map<VideoMaterialDb, VideoMaterialInfo>(videoDb);
            return result;
        }

        public void UpdateCourseLevel(string courseId, int level)
        {
            var course = courseRepository.GetById(courseId);
            course.Level = level;
            courseRepository.Update(course);
        }

        public IEnumerable<VideoMaterialInfo> GetCourseVideos(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            var videoListDb = course.Videos.ToList().AsReadOnly();
            var result = mapper.Map<IEnumerable<VideoMaterialDb>, IEnumerable<VideoMaterialInfo>>(videoListDb);
            return result;
        }

        public IEnumerable<CommentInfo> GetCourseComments(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            var commentListDb = course.Comments.ToList().AsReadOnly();
            var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentInfo>>(commentListDb);
            return result;
        }

    }
}
