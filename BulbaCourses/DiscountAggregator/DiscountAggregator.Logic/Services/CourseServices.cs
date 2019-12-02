using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Logic.Models;

namespace DiscountAggregator.Logic.Services
{
    class CourseServices : ICourseServices
    {
        //getById, GetAll... methods
        public Course GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return Courseware.GetById(id);
        }
        public IEnumerable<Course> GetAll()
        {
            return Courseware.GetAll();
        }
    }
}
