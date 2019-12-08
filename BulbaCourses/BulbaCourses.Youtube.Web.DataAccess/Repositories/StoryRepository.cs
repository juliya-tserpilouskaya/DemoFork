using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private YoutubeContext _context;

        public StoryRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Save story for User
        /// </summary>
        /// <param name="story"></param>
        public SearchStoryDb Save(SearchStoryDb story)
        {
            _context.SearchStories.Add(story);
            _context.SaveChanges();
            return story;
        }

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IEnumerable<SearchStoryDb> GetAll()
        {
            return _context.SearchStories.ToList().AsReadOnly();
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetByUserId(int? userId)
        {
            return _context.SearchStories.Where(s => s.User.Id == userId).ToList().AsReadOnly();
        }

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetByRequestId(int? requestId)
        {
            return _context.SearchStories.Where(s => s.SearchRequest.Id == requestId).ToList().AsReadOnly();
        }

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStoryDb GetByStoryId(int? storyId)
        {
            return _context.SearchStories.SingleOrDefault(s => s.Id == storyId);
        }

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteByUserId(int? userId)
        {
            var delstory = _context.SearchStories.Where(s => s.User.Id == userId);
            if (delstory != null)
            {
                _context.SearchStories.RemoveRange(delstory);
                _context.SaveChanges();
            }
        }
        public void DeleteByStoryId(int? storyId)
        {
            var delstory = _context.SearchStories.SingleOrDefault(s => s.Id == storyId);
            if (delstory != null)
            {
                _context.SearchStories.Remove(delstory);
                _context.SaveChanges();
            }
        }

    }
}
