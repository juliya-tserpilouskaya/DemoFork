using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Parsers;
using BulbaCourses.DiscountAggregator.Logic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseServices>().To<CourseServices>();
            Bind<ICourseITAcademyServices>().To<CourseITAcademyServices>();
            Bind<ICourseUdemyServices>().To<CourseUdemyServices>();
            Bind<ICourseBookmarkServices>().To<CourseBookmarkServices>();
            Bind<IDomainServices>().To<DomainServices>();
            Bind<ICourseCategoryServices>().To<CourseCategoryServices>();
            Bind<IUserProfileServices>().To<UserProfileServices>();
            Bind<ISearchCriteriaServices>().To<SearchCriteriaServices>();

            //DAL
            Bind<ICourseService>().To<CourseServiceDb>();
            Bind<IDomainServiceDb>().To<DomainServiceDb>();
            Bind<ICourseCategoryServiceDb>().To<CourseCategoryServiceDb>();
            Bind<IBookmarkServiceDb>().To<BookmarkServiceDb>();
            Bind<IUserProfileServiceDb>().To<UserProfileServiceDb>();
            Bind<ISearchCriteriaServiceDb>().To<SearchCriteriaServiceDb>();
            Bind<ICourseITAcademyServiceDb>().To<CourseITAcademyServiceDb>();
        }
    }
}
