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
        public void SaveStory(SearchStoryDb story)
        {
            if (story != null)
            {
                _storyRepository.Save(story);
            }
        }

        public void DeleteStory(string storyId)
        {
            if (!String.IsNullOrEmpty(storyId))
                _storyRepository.Delete(storyId);
        }

        public IEnumerable<SearchStoryDb> GetAllSrories()
        {
            return _storyRepository.GetAll();
        }

        public SearchStoryDb GetStoriesById(string storyId)
        {
            return _storyRepository.GetByStoryId(storyId);
        }

        public SearchStoryDb GetStoriesByUserId(string userId)
        {
            return _storyRepository.GetByUserId(userId);
        }

        public SearchStoryDb GetStoriesByRequestId(string requestId)
        {
            return _storyRepository.GetByRequestId(requestId);
        }
    }
}
