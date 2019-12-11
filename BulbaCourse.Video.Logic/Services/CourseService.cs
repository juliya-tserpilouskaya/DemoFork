using BulbaCourse.Video.Data.Interfaces;
using BulbaCourse.Video.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void AddCourse(CourseDb course)
        {
            courseRepository.Add(course);
        }

        public void AddDiscription(string courseId, string description)
        {
            var course = courseRepository.GetById(courseId);
            course.Description = description;
            courseRepository.Update(course);

        }

        public void AddVideoToCourse(string courseId, VideoMaterialDb video)
        {
            var courseVideos = courseRepository.GetById(courseId).Videos;
            courseVideos.Add(video);
        }

        public void AddTagToCourse(string courseId, TagDb tag)
        {
            var courseTags = courseRepository.GetById(courseId).Tags;
            courseTags.Add(tag);
        }

        public CourseDb GetCourseById(string courseId)
        {
            var result = courseRepository.GetById(courseId);
            return result;
        }

        public CourseDb GetCourseByName(string courseName)
        {
            var result = courseRepository.GetAll().FirstOrDefault(c => c.Name.Equals(courseName));
            return result;
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var result = courseRepository.GetAll();
            return result;
        }

        public void Delete(CourseDb course)
        {
            courseRepository.Remove(course);
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

        public IEnumerable<TagDb> GetTags(string courseId)
        {
            var courseTags = courseRepository.GetById(courseId).Tags.ToList().AsReadOnly();
            return courseTags;
        }

        public VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder)
        {
            var course = courseRepository.GetById(courseId);
            var result = course.Videos.FirstOrDefault(c => c.Order == videoOrder);
            return result;
        }

        public void UpdateCourseLevel(string courseId, int level)
        {
            var course = courseRepository.GetById(courseId);
            course.Level = level;
            courseRepository.Update(course);
        }

        public IEnumerable<VideoMaterialDb> GetCourseVideos(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            var result = course.Videos.ToList().AsReadOnly();
            return result;
        }

        public IEnumerable<CommentDb> GetCourseComments(string courseId)
        {
            var course = courseRepository.GetById(courseId);
            var result = course.Comments.ToList().AsReadOnly();
            return result;
        }
    }
}
