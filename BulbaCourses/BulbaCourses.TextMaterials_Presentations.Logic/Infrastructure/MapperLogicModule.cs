using AutoMapper;
using BulbaCourses.TextMaterials_Presentations.Data;
using Ninject.Modules;
using Presentations.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Logic
{
    public class MapperLogicModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseAdd_DTO, CourseDB>();
                cfg.CreateMap<Course, CourseDB>()
                    .ReverseMap();

                cfg.CreateMap<PresentationAdd_DTO, PresentationDB>();
                cfg.CreateMap<Presentation, PresentationDB>()
                    .ReverseMap();

                cfg.CreateMap<FeedbackAdd_DTO, FeedbackDB>();
                cfg.CreateMap<Feedback, FeedbackDB>()
                    .ReverseMap();

                cfg.CreateMap<UserAdd_DTO, StudentDB>();
                cfg.CreateMap<Student, StudentDB>()
                    .ReverseMap();

                cfg.CreateMap<TeacherAdd_DTO, TeacherDB>();
                cfg.CreateMap<Teacher, TeacherDB>()
                    .ReverseMap();
            });

            var mapper = new Mapper(mapperConfig);

            Bind<IMapper>().ToConstant(mapper);
        }
    }
}
