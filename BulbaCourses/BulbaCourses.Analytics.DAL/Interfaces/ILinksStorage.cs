using BulbaCourses.Analytics.DAL.Entities.Coupling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface ILinksStorage
    {
        List<Links> Storage { get; }
    }
}
