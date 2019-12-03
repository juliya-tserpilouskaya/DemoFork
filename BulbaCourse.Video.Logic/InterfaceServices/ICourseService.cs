using BulbaCourse.Video.Data.Enums;
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
        Course GetCourseById(string courseId);
        Course GetCourseByName(string courseName);
        IEnumerable<Course> GetAll();
        Course AddCourse(Course course);
        void Delete(Course course);
        void DeleteById(string courseId);
        Tag CheckTag(Tag tag);
        ICollection<Tag> GetTags(string courseId);
        ICollection<VideoMaterial> GetCourseVideos(string courseId);
        VideoMaterial GetVideoByOrder(string courseId, int videoOrder);
        CourseLevel GetCourseLevel(string courseId);
        void UpdateCourseLevel(string courseId, CourseLevel level);
        bool AddVideoToCourse(string courseId, string videoId);
        bool AddDiscription(string courseId, string discription);
    }
}
