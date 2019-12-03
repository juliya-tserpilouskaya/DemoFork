using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IAuditModel
    {
        DateTime? Created { get; set; }

        DateTime? Modified { get; set; }

        string Creator { get; set; }

        string Modifier { get; set; }
    }
}
