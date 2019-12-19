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
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            //return Courseware.GetById(id);
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = _courseService.GetAll();
            var result = mapper.Map<IEnumerable<CourseDb>, IEnumerable<Course>>(courses);
            //return _courseService.GetAll(); 
            return result;//Courseware.GetAll();
        }

        public Course Add(Course course)
        {
            throw new NotImplementedException();
        }

        
    }
}
