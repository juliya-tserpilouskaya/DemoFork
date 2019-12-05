using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.Infrastructure.DAL.Models
{
    /// <summary>
    /// Represents additional properties for auditing
    /// </summary>
    public interface IAuditModel
    {
        /// <summary>
        /// DateTime of Created. Optional.
        /// </summary>
        DateTime? Created { get; set; }

        /// <summary>
        /// DateTime of Modified. Optional.
        /// </summary>
        DateTime? Modified { get; set; }

        /// <summary>
        /// Creator Modifier
        /// </summary>
        string Creator { get; set; }

        /// <summary>
        /// Modifier Modifier
        /// </summary>
        string Modifier { get; set; }
    }
}
