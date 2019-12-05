using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.Infrastructure.DAL.Models
{
    public interface IChartDb
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
