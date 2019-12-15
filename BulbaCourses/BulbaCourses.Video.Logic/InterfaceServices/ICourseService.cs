using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface ICourseService
    {
        Task<CourseInfo> GetCourseByIdAsync(string courseId);
        CourseInfo GetCourseByName(string courseName);
        IEnumerable<CourseInfo> GetAll();
        Task<IEnumerable<CourseInfo>> GetAllAsync();

        void AddCourse(CourseInfo course);
        void Delete(CourseInfo course);
        void DeleteById(string courseId);
        void Update(CourseInfo course);
        void AddTagToCourse(string courseId, TagInfo tag);
        IEnumerable<TagInfo> GetTags(string courseId);
        IEnumerable<VideoMaterialInfo> GetCourseVideos(string courseId);
        VideoMaterialInfo GetVideoByOrder(string courseId, int videoOrder);
        int GetCourseLevel(string courseId);
        void UpdateCourseLevel(string courseId, int level);
        void AddVideoToCourse(string courseId, VideoMaterialInfo video);
        void AddDiscription(string courseId, string description);
        IEnumerable<CommentInfo> GetCourseComments(string courseId);

    }
}
