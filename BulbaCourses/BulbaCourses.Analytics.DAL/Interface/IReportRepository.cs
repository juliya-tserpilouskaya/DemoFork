using BulbaCourses.Analytics.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.DAL.Interface
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
        void Create(ReportDb item);

        /// <summary>
        /// Findes items in storage
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<ReportDb> Find(Func<ReportDb, bool> predicate);

        /// <summary>
        /// Updates an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Update(ReportDb item);

        /// <summary>
        /// Deletes an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Delete(ReportDb item);
    }
}
