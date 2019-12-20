using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IMapper mapper;
        private readonly ICourseService _courseService;

        public CourseServices(IMapper mapper, ICourseService courseService)
        {
            this.mapper = mapper;
            _courseService = courseService;
        }

        public Course GetById(string id)
        {
            var courses = _courseService.GetById(id);
            var result = mapper.Map<CourseDb, Course>(courses);
            return result;
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = _courseService.GetAll();
            var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<Course>>(courses);
            //return _courseService.GetAll(); 
            return result;//Courseware.GetAll();
        }

        public void Add(Course course)
        {
            var courseDb = mapper.Map<Course, CourseDb>(course);
            _courseService.Add(courseDb);
        }

        public void Delete(Course course)
        {
            var courseDb = mapper.Map<Course, CourseDb>(course);
            _courseService.Delete(courseDb);
        }

        public void Update(Course course)
        {
            var courseDb = mapper.Map<Course, CourseDb>(course);
            _courseService.Update(courseDb);
        }
    }
}
