using System;
using Ninject.Modules;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;

namespace Presentations.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseBaseService>().To<CourseBaseService>(); 
            Bind<ICoursePresentationsService>().To<CoursePresentationsService>();
            Bind<ICourseTeachersService>().To<CourseTeachersService>();
            Bind<IFeedbackService>().To<FeedbackService>();
            Bind<IPresentationsBaseService>().To<PresentationsBaseService>(); 
            Bind<IFavoritePresentationsService>().To<FavoritePresentationsService>();
            Bind<IStudentBaseService>().To<StudentBaseService>();
            Bind<IViewedPresentationsService>().To<ViewedPresentationsService>();
            Bind<IChangedPresentationsService>().To<ChangedPresentationsService>();
            Bind<IStaffService>().To<StaffService>();
        }
    }
}
