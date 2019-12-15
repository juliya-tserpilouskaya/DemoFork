using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IStoryService
    {
        /// <summary>
        /// Save story for User
        /// </summary>
        /// <param name="story"></param>
        SearchStoryDb Save(SearchStoryDb story);

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteByUserId(int? userId);

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        void DeleteByStoryId(int? storyId);

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetAllStories();

        Task<IEnumerable<SearchStoryDb>> GetAllStoriesAsync();

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetStoriesByUserId(int? userId);

        Task<IEnumerable<SearchStoryDb>> GetStoriesByUserIdAsync(int? userId);

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetStoriesByRequestId(int? requestId);

        Task<IEnumerable<SearchStoryDb>> GetStoriesByRequestIdAsync(int? requestId);

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        SearchStoryDb GetStoryByStoryId(int? storyId);

        Task<SearchStoryDb> GetStoryByStoryIdAsync(int? storyId);

    }
}
