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
        public Course GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return Courseware.GetById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return Courseware.GetAll();
        }

        public Course Add(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
