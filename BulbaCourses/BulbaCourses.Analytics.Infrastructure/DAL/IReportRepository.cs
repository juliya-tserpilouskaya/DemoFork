using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.Infrastructure.DAL
{
    /// <summary>
    /// Provides a mechanism for working Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReportRepository
    {
        /// <summary>
        /// Creates an item in repository
        /// </summary>
        /// <param name="item"></param>
        void Create(IReportDb item);

        /// <summary>
        /// Findes items in storage
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<IReportDb> Find(Func<IReportDb, bool> predicate);

        /// <summary>
        /// Updates an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Update(IReportDb item);

        /// <summary>
        /// Deletes an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Delete(IReportDb item);
    }
}
