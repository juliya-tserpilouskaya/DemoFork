using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface ICourseService
    {
        IEnumerable<CourseInfo> GetAll();
        void AddCourse(CourseInfo course);
        void Delete(CourseInfo course);
        void DeleteById(string courseId);

        CourseInfo GetCourseByName(string courseName);
        void AddTagToCourse(string courseId, TagInfo tag);
        IEnumerable<TagInfo> GetTags(string courseId);
        IEnumerable<VideoMaterialInfo> GetCourseVideos(string courseId);
        VideoMaterialInfo GetVideoByOrder(string courseId, int videoOrder);
        int GetCourseLevel(string courseId);
        void UpdateCourseLevel(string courseId, int level);
        void AddVideoToCourse(string courseId, VideoMaterialInfo video);
        void AddDiscription(string courseId, string description);

        Task<IEnumerable<CourseInfo>> GetAllAsync();
        Task<CourseInfo> GetCourseByIdAsync(string courseId);
        Task<IEnumerable<CourseInfo>> GetListByTagAsync(TagInfo tag);
        Task<IEnumerable<CourseInfo>> GetCoursesByNameAsync(string courseName);
        Task<Result<CourseInfo>> RateCourse(CourseInfo course, int Assessment);


        Task<Result<CourseInfo>> UpdateAsync(CourseInfo course);
        Task<Result<CourseInfo>> AddCourseAsync(CourseInfo courseInfo);
        Task<Result> DeleteByIdAsync(string id);
        Task<bool> ExistNameAsync(string courseName);
        Task<Result> AddVideoAsync(CourseInfo course, VideoMaterialInfo video);
        Task<Result> AddTagAsync(CourseInfo course, TagInfo tag);
        Task<Result<CourseInfo>> ChangeLevel(CourseInfo course, int level);
    }
}
