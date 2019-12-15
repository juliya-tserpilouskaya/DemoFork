using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepository;
        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        /// <summary>
        /// Save current search request as story for User
        /// </summary>
        /// <param name="story"></param>
        public SearchStoryDb Save(SearchStoryDb story)
        {
            return story != null ? _storyRepository.Save(story) : story;
        }

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteByUserId(int? userId)
        {
            if (userId != null)
                _storyRepository.DeleteByUserId(userId);
        }

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        public void DeleteByStoryId(int? storyId)
        {
            if (storyId!=null)
                _storyRepository.DeleteByStoryId(storyId);
        }

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetAllStories()
        {
            return _storyRepository.GetAll();
        }

        public async Task<IEnumerable<SearchStoryDb>> GetAllStoriesAsync()
        {
            return await _storyRepository.GetAllAsync();
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetStoriesByUserId(int? userId)
        {
            return _storyRepository.GetByUserId(userId);
        }

        public async Task<IEnumerable<SearchStoryDb>> GetStoriesByUserIdAsync(int? userId)
        {
            return await _storyRepository.GetByUserIdAsync(userId);
        }

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetStoriesByRequestId(int? requestId)
        {
            return _storyRepository.GetByRequestId(requestId);
        }

        public async Task<IEnumerable<SearchStoryDb>> GetStoriesByRequestIdAsync(int? requestId)
        {
            return await _storyRepository.GetByRequestIdAsync(requestId);            
        }

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStoryDb GetStoryByStoryId(int? storyId)
        {
            return _storyRepository.GetByStoryId(storyId);
        }

        public async Task<SearchStoryDb> GetStoryByStoryIdAsync(int? storyId)
        {
            return await _storyRepository.GetByStoryIdAsync(storyId);
        }
        //public async Task<SearchStory> GetStoryByStoryIdAsync(int? storyId)
        //{
        //    var result = await _storyRepository.GetByStoryIdAsync(storyId);
        //    return result == null ? null : new SearchStory() { Id = result.Id, SearchDate = result.SearchDate, SearchRequestId = result.SearchRequest.Id, UserId = result.User.Id };
        //}
    }
}
