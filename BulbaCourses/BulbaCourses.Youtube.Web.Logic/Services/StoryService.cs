using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using AutoMapper;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepository;
        Mapper _mapper;
        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg=>cfg.CreateMap<SearchStoryDb, SearchStory>()));
        }

        /// <summary>
        /// Save current search request as story for User
        /// </summary>
        /// <param name="story"></param>
        public SearchStory Save(SearchStoryDb story)
        {
            return _mapper.Map<SearchStory>(story != null ? _storyRepository.Save(story) : story);
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
        public IEnumerable<SearchStory> GetAllStories()
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetAll());
        }

        public async Task<IEnumerable<SearchStory>> GetAllStoriesAsync()
        {
            return await _mapper.Map<Task<IEnumerable<SearchStory>>>(_storyRepository.GetAllAsync());
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByUserId(int? userId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetByUserId(userId));
        }

        public async Task<IEnumerable<SearchStory>> GetStoriesByUserIdAsync(int? userId)
        {
            return await _mapper.Map<Task<IEnumerable<SearchStory>>>(_storyRepository.GetByUserIdAsync(userId));
        }

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByRequestId(int? requestId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetByRequestId(requestId));
        }

        public async Task<IEnumerable<SearchStory>> GetStoriesByRequestIdAsync(int? requestId)
        {
            return await _mapper.Map<Task<IEnumerable<SearchStory>>>(_storyRepository.GetByRequestIdAsync(requestId));            
        }

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStory GetStoryByStoryId(int? storyId)
        {
            return _mapper.Map<SearchStory>(_storyRepository.GetByStoryId(storyId));
        }

        public async Task<SearchStory> GetStoryByStoryIdAsync(int? storyId)
        {
            return await _mapper.Map<Task<SearchStory>>(_storyRepository.GetByStoryIdAsync(storyId));
        }
    }
}
