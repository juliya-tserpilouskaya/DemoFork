using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;

namespace BulbaCourses.GlobalSearch.Data.EntitiesConfiguration.CoursesConfiguration
{
    class ArticleCourseConfiguration : EntityTypeConfiguration<ArticleCourseDB>
    {
        public ArticleCourseConfiguration()
        {

        }
    }
}
