using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using BulbaCourses.DiscountAggregator.Logic.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseITAcademyServices : ICourseITAcademyServices
    {
        private readonly IMapper _mapper;
        private readonly ICourseITAcademyServiceDb _courseServiceDb;
        private readonly ParserITAcademy _parserITAcademy;

        public CourseITAcademyServices(IMapper mapper, ICourseITAcademyServiceDb serviceDb)
        {
            this._mapper = mapper;
            _courseServiceDb = serviceDb;
            _parserITAcademy = new ParserITAcademy();
        }

        public async Task<Result<IEnumerable<Course>>> AddRangeAsync()
        {
            var listCategories = _parserITAcademy.GetCategories().Distinct();
            List<Course> listCourses = new List<Course>();
            foreach(var el in listCategories)
            {
                listCourses.AddRange(_parserITAcademy.GetAllCourses(el));
            }
            var listCoursesDb = _mapper.Map<IEnumerable<CourseDb>>(listCourses);
            var result = await _courseServiceDb.AddRangeAsync(listCoursesDb);
            return result.IsSuccess ? Result<IEnumerable<Course>>.Ok(_mapper.Map <IEnumerable<Course>>(result.Data))
                : Result <IEnumerable<Course>>.Fail <IEnumerable<Course>>(result.Message);
        }

        public Task<IEnumerable<CoursesITAcademy>> GetAllAsync()
        {
            return Task.FromResult(CourseITAcademyStorage.GetAll().AsEnumerable());
        }
    }
}
