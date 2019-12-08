using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

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

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetStoriesByUserId(int? userId)
        {
            return _storyRepository.GetByUserId(userId);
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

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStoryDb GetStoryByStoryId(int? storyId)
        {
            return _storyRepository.GetByStoryId(storyId);
        }
    }
}
