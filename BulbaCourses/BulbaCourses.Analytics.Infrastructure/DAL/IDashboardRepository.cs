using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.Infrastructure.DAL
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
        void Create(IDashboardDb item);

        /// <summary>
        /// Findes items in storage
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<IDashboardDb> Find(Func<IDashboardDb, bool> predicate);

        /// <summary>
        /// Updates an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Update(IDashboardDb item);

        /// <summary>
        /// Deletes an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Delete(IDashboardDb item);
    }
}
