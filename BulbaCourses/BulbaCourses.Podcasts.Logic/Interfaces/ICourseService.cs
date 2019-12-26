using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICourseService
    {
        void AddCourse(CourseLogic course);

        void AddDiscription(string Id, string description);

        void AddFileToCourse(string Id, AudioLogic audio);

        CourseLogic GetById(string Id);

        CourseLogic GetCourseByName(string courseName);

        IEnumerable<CourseLogic> GetAll();

        void Delete(CourseLogic course);
        void Update(CourseLogic course);

        IEnumerable<AudioLogic> GetCourseAudios(string Id);

        IEnumerable<CommentLogic> GetCourseComments(string Id);

    }
}
