using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public CourseDb GetById(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            return course;
        }

        public void Add(CourseDb course)
        {
            videoDbContext.Courses.Add(course);
            videoDbContext.SaveChanges();
        }

        public CourseDb GetByName(string courseName)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.Name.Equals(courseName));
            return course;
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var courseList = videoDbContext.Courses.ToList().AsReadOnly();
            return courseList;
        }

        public void Update(CourseDb course)
        {
            videoDbContext.Entry(course).State = EntityState.Modified;
            videoDbContext.SaveChanges();
        }

        public void Remove(CourseDb course)
        {
            videoDbContext.Courses.Remove(course);
            videoDbContext.SaveChanges();
        }
        public void RemoveById(string courseId)
        {
            var deleteCourse = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            videoDbContext.Courses.Remove(deleteCourse);
            videoDbContext.SaveChanges();
        }

        public TagDb AddTag(string content)
        {
            var result = videoDbContext.Tags.FirstOrDefault(p => p.Content.Equals(content));
            if (result == null)
            {
                TagDb tag = new TagDb()
                {
                    Content = content
                };
                videoDbContext.Tags.Add(tag);
                videoDbContext.SaveChanges();
                result = tag;
            }
            return result;
        }

            public IEnumerable<TagDb> GetTags(string courseId)
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

        public IEnumerable<VideoMaterialDb> GetCourseVideos(string courseId)
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

        public int GetCourseLevel(string courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            int level = course.Level;
            return level;
        }

        public void UpdateCourseLevel(string courseId, int level)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            course.Level = level;
        }
    }
}
