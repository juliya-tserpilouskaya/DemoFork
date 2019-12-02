using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountAggregator.Logic.Services
{
    public interface ICourseServices
    {
        Course GetById(string id);
    }
}
