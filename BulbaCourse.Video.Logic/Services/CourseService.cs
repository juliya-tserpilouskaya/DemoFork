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

        public bool AddDiscription(string courseId, string discription)
        {
            var result = courseRepository.AddDiscription(courseId, discription);
            return result;

        }

        public bool AddVideoToCourse(string courseId, string videoId)
        {
            var result = courseRepository.AddVideoToCourse(courseId, videoId);
            return result;
        }

        public TagDb CheckTag(TagDb tag)
        {
            var result = courseRepository.CheckTag(tag);
            return result;
        }

        public CourseDb GetCourseById(string courseId)
        {
            var result = courseRepository.GetById(courseId);
            return result;
        }

        public CourseDb GetCourseByName(string courseName)
        {
            var result = courseRepository.GetByName(courseName);
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
            courseRepository.RemoveById(courseId);
        }

        public int GetCourseLevel(string courseId)
        {
            var result = courseRepository.GetCourseLevel(courseId);
            return result;
        }

        public IEnumerable<VideoMaterialDb> GetCourseVideos(string courseId)
        {
            var result = courseRepository.GetCourseVideos(courseId);
            return result;
        }

        public IEnumerable<TagDb> GetTags(string courseId)
        {
            var result = courseRepository.GetTags(courseId);
            return result;
        }

        public VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder)
        {
            var result = courseRepository.GetVideoByOrder(courseId, videoOrder);
            return result;
        }

        public void UpdateCourseLevel(string courseId, int level)
        {
            courseRepository.UpdateCourseLevel(courseId, level);
        }
    }
}
