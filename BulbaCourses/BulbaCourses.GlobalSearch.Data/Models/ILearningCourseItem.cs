using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Data.Enums;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public interface ILearningCourseItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Category Category { get; set; }

        DateTime? Created { get; set; }
        DateTime? Modified { get; set; }

    }
}
