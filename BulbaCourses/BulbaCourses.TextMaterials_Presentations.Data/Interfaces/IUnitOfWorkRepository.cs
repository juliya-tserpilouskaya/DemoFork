using BulbaCourses.TextMaterials_Presentations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        PresentationsContext Context { get; }

        IRepository<CourseDB> Courses { get; }
        IRepository<FeedbackDB> Feedbacks { get; }
        IRepository<PresentationDB> Presentations { get; }
        IRepository<StudentDB> Students { get; }
        IRepository<TeacherDB> Teachers { get; }

        ICourseLoadingRepository CourseLoading { get; }
        IPresentationsLoadingRepository PresentationsLoading { get; }
        ITeacherLoadingRepository TeacherLoading { get; }
        IStudentLoadingRepository StudentLoading { get; }

        /// <summary>
        /// Save the changes in the database
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
