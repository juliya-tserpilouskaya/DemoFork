using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private YoutubeContext _context;
        private bool _isDisposed = false;

        public StoryRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Save Changes Async
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
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
        public IEnumerable<SearchStoryDb> GetAll()
        {
            return _context.SearchStories.ToList().AsReadOnly();
        }

        /// <summary>
        /// Get async all stories for all Users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SearchStoryDb>> GetAllAsync()
        {
            return await _context.SearchStories.ToListAsync();
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStoryDb> GetByUserId(string userId)
        {
            return _context.SearchStories.Include(_=>_.SearchRequest).Where(s => s.UserId == userId).ToList().AsReadOnly();
        }

        /// <summary>
        /// Get async all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchStoryDb>> GetByUserIdAsync(string userId)
        {
            return await _context.SearchStories.Include(_ => _.SearchRequest).Where(s => s.UserId == userId).ToListAsync();
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
        /// Get async all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchStoryDb>> GetByRequestIdAsync(int? requestId)
        {
            return await _context.SearchStories.Where(s => s.SearchRequest.Id == requestId).ToListAsync();
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
        /// Get async one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<SearchStoryDb> GetByStoryIdAsync(int? storyId)
        {
            return await _context.SearchStories.SingleOrDefaultAsync(s => s.Id == storyId);
        }

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteByUserId(string userId)
        {
            var delstory = _context.SearchStories.Where(s => s.UserId == userId);
            if (delstory != null)
            {
                _context.SearchStories.RemoveRange(delstory);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete story by id
        /// </summary>
        /// <param name="storyId"></param>
        public void DeleteByStoryId(int? storyId)
        {
            var delstory = _context.SearchStories.SingleOrDefault(s => s.Id == storyId);
            if (delstory != null)
            {
                _context.SearchStories.Remove(delstory);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Hide story for user
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool HideStoryForUser(int? storyId, string userId)
        {
            var hideStory = _context.SearchStories.SingleOrDefault(s => s.Id == storyId && s.UserId == userId);
            var isHide = false;
            if (hideStory != null)
            {
                isHide = true;
                hideStory.IsHideForUser = isHide;
                _context.SaveChanges();
            }
            return isHide;
        }

        public async Task<bool> ExistsAsync(int? storyId)
        {
            return await _context.SearchStories.AnyAsync(s => s.Id == storyId);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            _context.Dispose();
            _isDisposed = true;

            if (flag)
                GC.SuppressFinalize(this);
        }
    }
}
