using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface IStoryService
    {
        /// <summary>
        /// Save story for User
        /// </summary>
        /// <param name="story"></param>
        SearchStory Save(SearchStory story);

        /// <summary>
        /// Save story for User async
        /// </summary>
        /// <param name="story"></param>
        Task<Result<SearchStory>> SaveAsync(SearchStory story);

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteByUserId(string userId);

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        Task<Result> DeleteByUserIdAsync(string userId);

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        void DeleteByStoryId(int? storyId);

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        Task<Result> DeleteByStoryIdAsync(int? storyId);

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<SearchStory> GetAllStories();

        /// <summary>
        /// Get asunc all stories for all Users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SearchStory>> GetAllStoriesAsync();

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<SearchStory> GetStoriesByUserId(string userId);

        /// <summary>
        /// Get async all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchStory>> GetStoriesByUserIdAsync(string userId);

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        IEnumerable<SearchStory> GetStoriesByRequestId(int? requestId);

        /// <summary>
        /// Get async all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchStory>> GetStoriesByRequestIdAsync(int? requestId);

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        SearchStory GetStoryByStoryId(int? storyId);

        /// <summary>
        /// Get async one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        Task<SearchStory> GetStoryByStoryIdAsync(int? storyId);

        Task<bool> ExistsAsync(int? storyId);

    }
}
