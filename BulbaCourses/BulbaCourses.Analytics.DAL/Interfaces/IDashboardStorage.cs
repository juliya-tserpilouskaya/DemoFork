using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IDashboardStorage
    {
        List<IDashboardDb> Storage { get; }
    }
}
