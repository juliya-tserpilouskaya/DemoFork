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
        CourseLogic AddCourse(CourseLogic course);

        void AddDiscription(string Id, string description);

        AudioLogic AddFileToCourse(string Id, AudioLogic audio);

        CourseLogic GetById(string Id);

        CourseLogic GetCourseByName(string courseName);

        IEnumerable<CourseLogic> GetAll();

        void Delete(CourseLogic course);

        CourseLogic Update(CourseLogic course);

        IEnumerable<AudioLogic> GetCourseAudios(string Id);

        IEnumerable<CommentLogic> GetCourseComments(string Id);

        bool Exists(string name);
    }
}
