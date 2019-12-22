using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interface
{
    /// <summary>
    /// Represents a mechanism for working repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Creates an item in the repository.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T item);

        /// <summary>
        /// Reads an item in the repository.
        /// </summary>
        /// <param name="firstOrDefaultAsyncCondition"></param>
        /// <returns></returns>
        Task<T> ReadAsync(
            Expression<Func<T, bool>> firstOrDefaultAsyncCondition);

        /// <summary>
        /// Reads an items in the repository.
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <param name="orderByCondition"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ReadAllAsync(
            Expression<Func<T, bool>> whereCondition, 
            Expression<Func<T, object>> orderByCondition);

        /// <summary>
        /// Reads an items in the repository.
        /// </summary>
        /// <param name="orderByCondition"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ReadAllAsync(
            Expression<Func<T, object>> orderByCondition);

        /// <summary>
        /// Updates an item in the repository.
        /// </summary>
        /// <param name="item"></param>
        Task<T> UpdateAsync(T item);

        /// <summary>
        /// Deletes an item in the repository.
        /// </summary>
        /// <param name="includeCondition"></param>
        /// <param name="firstOrDefaultAsyncCondition"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(
            Expression<Func<T, object>> includeCondition,
            Expression<Func<T, bool>> firstOrDefaultAsyncCondition);

        /// <summary>
        /// Deletes an item in the repository.
        /// </summary>
        /// <param name="firstOrDefaultAsyncCondition"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(
            Expression<Func<T, bool>> firstOrDefaultAsyncCondition);

        /// <summary>
        /// Deletes an item in the repository.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T item);

        /// <summary>
        /// Gets true if the element exists, otherwise false.
        /// </summary>
        /// <param name="anyAsyncCondition"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(
            Expression<Func<T, bool>> anyAsyncCondition);
    }
}
