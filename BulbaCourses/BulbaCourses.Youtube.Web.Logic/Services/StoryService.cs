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
        public SearchStory Save(SearchStory story)
        {
            var storyDb = new SearchStoryDb() { Id = story.Id, SearchDate = story.SearchDate, SearchRequest = new SearchRequestDb() { Id = story.SearchRequestId }, User = new UserDb() { Id = story.UserId } };
            storyDb = _storyRepository.Save(storyDb);
            return story == null ? null : new SearchStory() { Id = storyDb.Id, SearchDate = storyDb.SearchDate, SearchRequestId = storyDb.SearchRequest.Id, UserId = storyDb.User.Id};
        }
        //public SearchStoryDb Save(SearchStoryDb story)
        //{
        //    return story != null ? _storyRepository.Save(story) : story;
        //}

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
        public IEnumerable<SearchStory> GetAllStories()
        {
            return _storyRepository.GetAll().Select(item => new SearchStory()
            {
                Id = item.Id,
                SearchDate = item.SearchDate,
                SearchRequestId = item.SearchRequest.Id,
                UserId = item.User.Id
            });
        }

        //public async Task<IEnumerable<SearchStoryDb>> GetAllStoriesAsync()
        //{
        //    return await _storyRepository.GetAllAsync();
        //}

        public async Task<IEnumerable<SearchStory>> GetAllStoriesAsync()
        {
            var result = await _storyRepository.GetAllAsync();
            return result == null ? null : result.Select(item => new SearchStory() { Id = item.Id, SearchDate = item.SearchDate, SearchRequestId = item.SearchRequest.Id, UserId = item.User.Id });
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByUserId(int? userId)
        {
            return _storyRepository.GetByUserId(userId).Select(item => new SearchStory()
            {
                Id = item.Id,
                SearchDate = item.SearchDate,
                SearchRequestId = item.SearchRequest.Id,
                UserId = item.User.Id
            });
        }

        //public async Task<IEnumerable<SearchStoryDb>> GetStoriesByUserIdAsync(int? userId)
        //{
        //    return await _storyRepository.GetByUserIdAsync(userId);
        //}

        public async Task<IEnumerable<SearchStory>> GetStoriesByUserIdAsync(int? userId)
        {
            var result = await _storyRepository.GetByUserIdAsync(userId);
            return result == null ? null : result.Select(item => new SearchStory() { Id = item.Id, SearchDate = item.SearchDate, SearchRequestId = item.SearchRequest.Id, UserId = item.User.Id });
        }

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByRequestId(int? requestId)
        {
            return _storyRepository.GetByRequestId(requestId).Select(item => new SearchStory()
            {
                Id = item.Id,
                SearchDate = item.SearchDate,
                SearchRequestId = item.SearchRequest.Id,
                UserId = item.User.Id
            });
        }

        //public async Task<IEnumerable<SearchStoryDb>> GetStoriesByRequestIdAsync(int? requestId)
        //{
        //    return await _storyRepository.GetByRequestIdAsync(requestId);            
        //}

        public async Task<IEnumerable<SearchStory>> GetStoriesByRequestIdAsync(int? requestId)
        {
            var result = await _storyRepository.GetByRequestIdAsync(requestId);
            return result == null ? null : result.Select(item => new SearchStory() { Id = item.Id, SearchDate = item.SearchDate, SearchRequestId = item.SearchRequest.Id, UserId = item.User.Id });
        }

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStory GetStoryByStoryId(int? storyId)
        {
            var result = _storyRepository.GetByStoryId(storyId);
            return result == null ? null : new SearchStory() { Id = result.Id, SearchDate = result.SearchDate, SearchRequestId = result.SearchRequest.Id, UserId = result.User.Id };
        }

        //public async Task<SearchStoryDb> GetStoryByStoryIdAsync(int? storyId)
        //{
        //    return await _storyRepository.GetByStoryIdAsync(storyId);
        //}
        public async Task<SearchStory> GetStoryByStoryIdAsync(int? storyId)
        {
            var result = await _storyRepository.GetByStoryIdAsync(storyId);
            return result == null ? null : new SearchStory() { Id = result.Id, SearchDate = result.SearchDate, SearchRequestId = result.SearchRequest.Id, UserId = result.User.Id };
        }
    }
}
