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
        void SaveStory(SearchStoryDb story);

        void DeleteStory(string storyId);

        IEnumerable<SearchStoryDb> GetAllSrories();

        SearchStoryDb GetStoriesById(string storyId);

        SearchStoryDb GetStoriesByUserId(string userId);

        SearchStoryDb GetStoriesByRequestId(string requestId);
    }
}
