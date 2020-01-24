using System;
using AutoMapper;
using Ninject.Modules;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;
using BulbaCourses.TextMaterials_Presentations.Data;

namespace Presentations.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICoursesService>().To<CourseService>();
            Bind<IFeedbacksService>().To<FeedbackService>();
            Bind<IPresentationsService> ().To<PresentationsService>();
            Bind<IStudentService>().To<StudentService>(); 
            Bind<ITeacherService>().To<TeacherService>();

            this.Kernel?.Load(new[] { new DbModule() });
        }
    }
}
