using BulbaCourses.Analytics.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interface
{
    /// <summary>
    /// Provides a mechanism for working Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDashboardRepository
    {
        /// <summary>
        /// Creates an item in repository
        /// </summary>
        /// <param name="item"></param>
        void Create(DashboardDb item);

        /// <summary>
        /// Findes items in storage
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<DashboardDb> Find(Func<DashboardDb, bool> predicate);

        /// <summary>
        /// Updates an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Update(DashboardDb item);

        /// <summary>
        /// Deletes an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Delete(DashboardDb item);
    }
}
