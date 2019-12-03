using BulbaCourse.Video.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface ICourseRepository
    {
        CourseDb GetCourseById(string courseId);
        CourseDb GetCourseByName(string courseName);
        IEnumerable<CourseDb> GetAll();
        CourseDb AddCourse(CourseDb course);
        void Delete(CourseDb course);
        void DeleteById(string courseId);
        TagDb CheckTag(TagDb tag);
        ICollection<TagDb> GetTags(string courseId);
        ICollection<VideoMaterialDb> GetCourseVideos(string courseId);
        VideoMaterialDb GetVideoByOrder(string courseId, int videoOrder);
        CourseLevel GetCourseLevel(string courseId);
        void UpdateCourseLevel(string courseId, CourseLevel level);
        bool AddVideoToCourse(string courseId, string videoId);
        bool AddDiscription(string courseId, string discription);
    }
}
