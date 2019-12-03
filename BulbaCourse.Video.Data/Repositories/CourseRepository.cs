using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Enums;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly VideoDbContext videoDbContext;

        public CourseRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }
        public CourseDb GetCourseById(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            return course;
        }

        public CourseDb AddCourse(CourseDb course)
        {
            videoDbContext.Courses.Add(course);
            videoDbContext.SaveChanges();
            return course;
        }

        public CourseDb GetCourseByName(string courseName)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.Name.Equals(courseName));
            return course;
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var courseList = videoDbContext.Courses.ToList().AsReadOnly();
            return courseList;
        }

        public void Delete(CourseDb course)
        {
            videoDbContext.Courses.Remove(course);
            videoDbContext.SaveChanges();
        }
        public void DeleteById(string courseId)
        {
            var deleteCourse = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            videoDbContext.Courses.Remove(deleteCourse);
            videoDbContext.SaveChanges();
        }

        public TagDb CheckTag(TagDb tag)
        {
            var result = videoDbContext.Tags.FirstOrDefault(p => p.Content == tag.Content);
            if (result == null)
            {
                videoDbContext.Tags.Add(tag);
                videoDbContext.SaveChanges();
                result = tag;
            }
            return result;
        }

        public ICollection<TagDb> GetTags(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(p => p.CourseId.Equals(courseId));
            var tags = course.Tags;
            return tags;
        }

        public bool AddVideoToCourse(string courseId, string videoId)
        {
            var video = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            if (video != null)
            {
                var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
                course.Videos.Add(video);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<VideoMaterialDb> GetCourseVideos(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var videos = course.Videos;
            return videos;
        }

        public VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var videos = course.Videos;
            var video = videos.FirstOrDefault(b => b.Order == videoOrder);
            return video;
        }

        public bool AddDiscription(string courseId, string discription)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var discript = course.Description;
            if (discript == null)
            {
                discript = discription;
                return true;
            }
            else
            {
                return false;
            }
        }

        public CourseLevel GetCourseLevel(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            CourseLevel level = course.Level;
            return level;
        }

        public void UpdateCourseLevel(string courseId, CourseLevel level)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            course.Level = level;
        }
    }
}
