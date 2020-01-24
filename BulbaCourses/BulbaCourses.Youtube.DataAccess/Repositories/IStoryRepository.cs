using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public interface IStoryRepository : IDisposable
    {
        /// <summary>
        /// Save Changes Async
        /// </summary>
        /// <returns></returns>
        Task SaveChangeAsync();

        /// <summary>
        /// Save story for User
        /// </summary>
        /// <param name="story"></param>
        SearchStoryDb Save(SearchStoryDb story);

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteByUserId(string userId);

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        void DeleteByStoryId(int? storyId);

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetAll();

        /// <summary>
        /// Get async all stories for all Users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SearchStoryDb>> GetAllAsync();

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetByUserId(string userId);

        /// <summary>
        /// Get async all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchStoryDb>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetByRequestId(int? requestId);

        /// <summary>
        /// Get async all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchStoryDb>> GetByRequestIdAsync(int? requestId);

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        SearchStoryDb GetByStoryId(int? storyId);

        /// <summary>
        /// Get async one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        Task<SearchStoryDb> GetByStoryIdAsync(int? storyId);

        /// <summary>
        /// Check story async
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(int? storyId);

        /// <summary>
        /// Hide async story for user when user click delete
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool HideStoryForUser(int? storyId, string userId);
    }
}
