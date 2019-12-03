using BulbaCourse.Video.Data.Enums;
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

        public Course AddCourse(Course course)
        {
            return courseRepository.AddCourse(course);
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

        public Tag CheckTag(Tag tag)
        {
            var result = courseRepository.CheckTag(tag);
            return result;
        }

        public Course GetCourseById(string courseId)
        {
            var result = courseRepository.GetCourseById(courseId);
            return result;
        }

        public Course GetCourseByName(string courseName)
        {
            var result = courseRepository.GetCourseByName(courseName);
            return result;
        }

        public IEnumerable<Course> GetAll()
        {
            var result = courseRepository.GetAll();
            return result;
        }

        public void Delete(Course course)
        {
            courseRepository.Delete(course);
        }

        public void DeleteById(string courseId)
        {
            courseRepository.DeleteById(courseId);
        }

        public CourseLevel GetCourseLevel(string courseId)
        {
            var result = courseRepository.GetCourseLevel(courseId);
            return result;
        }

        public ICollection<VideoMaterial> GetCourseVideos(string courseId)
        {
            var result = courseRepository.GetCourseVideos(courseId);
            return result;
        }

        public ICollection<Tag> GetTags(string courseId)
        {
            var result = courseRepository.GetTags(courseId);
            return result;
        }

        public VideoMaterial GetVideoByOrder(string courseId, int videoOrder)
        {
            var result = courseRepository.GetVideoByOrder(courseId, videoOrder);
            return result;
        }

        public void UpdateCourseLevel(string courseId, CourseLevel level)
        {
            courseRepository.UpdateCourseLevel(courseId, level);
        }
    }
}
