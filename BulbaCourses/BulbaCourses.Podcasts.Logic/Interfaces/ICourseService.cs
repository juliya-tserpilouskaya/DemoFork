using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICourseService : IBaseService<CourseLogic>
    {
        Result Add(CourseLogic course);

        bool Exists(string name);

        Result<IEnumerable<CourseLogic>> Search(string Name);
    }
}
