using BulbaCourses.TextMaterials_Presentations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {  
        public UnitOfWorkRepository()
        {
            Context = new PresentationsContext();
        }

        public UnitOfWorkRepository(PresentationsContext context)
        {
            Context = context;
        }

        public PresentationsContext Context { get; }

        private CourseDbRepository _courseDbRepository;
        private FeedbackDbRepository _feedbackDbRepository;
        private PresentationDbRepository _presentationDbRepository;
        private TeacherDbRepository _teacherDbRepository;
        private StudentDbRepository _studentDbRepository;

        private CourseDbRepository _courseLoading;
        private PresentationDbRepository _presentationLoading;
        private TeacherDbRepository _teacherLoading;
        private StudentDbRepository _studentLoading;

        private bool _isDisposed = false;

        public IRepository<CourseDB> Courses =>
            _courseDbRepository ?? (_courseDbRepository = new CourseDbRepository(Context));

        public IRepository<FeedbackDB> Feedbacks =>
            _feedbackDbRepository ?? (_feedbackDbRepository = new FeedbackDbRepository(Context));

        public IRepository<PresentationDB> Presentations => 
            _presentationDbRepository ?? (_presentationDbRepository = new PresentationDbRepository(Context));

        public IRepository<TeacherDB> Teachers => 
            _teacherDbRepository ?? (_teacherDbRepository = new TeacherDbRepository(Context));

        public IRepository<StudentDB> Students =>
            _studentDbRepository ?? (_studentDbRepository = new StudentDbRepository(Context));

        public ICourseLoadingRepository CourseLoading =>
            _courseLoading ?? (_courseLoading = new CourseDbRepository(Context));

        public IPresentationsLoadingRepository PresentationsLoading =>
            _presentationLoading ?? (_presentationLoading = new PresentationDbRepository(Context));

        public ITeacherLoadingRepository TeacherLoading =>
            _teacherLoading ?? (_teacherLoading = new TeacherDbRepository(Context));

        public IStudentLoadingRepository StudentLoading =>
            _studentLoading ?? (_studentLoading = new StudentDbRepository(Context));

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        #region Disposable
        public void Dispose()
        {
            this.Dispose(true);
        }

        protected void Dispose(bool flag)
        {
            if (_isDisposed) return;

            Context?.Dispose();
            _isDisposed = true;
            if (flag) GC.SuppressFinalize(this);
        }

        ~UnitOfWorkRepository()
        {
            this.Dispose(false);
        }
        #endregion
    }
}
