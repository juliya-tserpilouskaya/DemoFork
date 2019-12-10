using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.InterfaceServices
{
    public interface ICourseService
    {
        CourseDb GetCourseById(string courseId);
        CourseDb GetCourseByName(string courseName);
        IEnumerable<CourseDb> GetAll();
        void AddCourse(CourseDb course);
        void Delete(CourseDb course);
        void DeleteById(string courseId);
        void AddTagToCourse(string courseId, TagDb tag);
        IEnumerable<TagDb> GetTags(string courseId);
        IEnumerable<VideoMaterialDb> GetCourseVideos(string courseId);
        VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder);
        int GetCourseLevel(string courseId);
        void UpdateCourseLevel(string courseId, int level);
        void AddVideoToCourse(string courseId, VideoMaterialDb video);
        void AddDiscription(string courseId, string description);
        IEnumerable<CommentDb> GetCourseComments(string courseId);
    }
}
