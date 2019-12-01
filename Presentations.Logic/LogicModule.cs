using System;
using Ninject.Modules;
using Presentations.Logic.Models.Course.InterfacesCourse;
using Presentations.Logic.Models.Course.CourseServices;
using Presentations.Logic.Models.Presentations.InterfacesPresentations;
using Presentations.Logic.Models.Presentations.PresentationsServices;

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
        }
    }
}
