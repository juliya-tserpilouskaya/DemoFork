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
        private YoutubeContext context;

        public StoryRepository(YoutubeContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SearchStoryDb> GetAll()
        {
            return context.SearchStories.ToList().AsReadOnly();
        }

        public SearchStoryDb GetByStoryId(string storyId)
        {
            return context.SearchStories.SingleOrDefault(s => s.Id == storyId);
        }

        public SearchStoryDb GetByUserId(string userId)
        {
            return context.SearchStories.SingleOrDefault(s => s.User.Id == userId);
        }

        public SearchStoryDb GetByRequestId(string requestId)
        {
            return context.SearchStories.SingleOrDefault(r => r.SearchRequest.Id == requestId);
        }

        public void Save(SearchStoryDb story)
        {
            if (string.IsNullOrEmpty(story.Id))
            {
                context.SearchStories.Add(story);
            }

            context.SaveChanges();
        }

        public void Delete(string storyId)
        {
            var delstory = context.SearchStories.SingleOrDefault(r => r.Id == storyId);
            if (delstory != null)
            {
                context.SearchStories.Remove(delstory);
                context.SaveChanges();
            }
        }
    }
}
