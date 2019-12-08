using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IStoryRepository
    {
        IEnumerable<SearchStoryDb> GetAll();
        SearchStoryDb GetByStoryId(string storyId);
        SearchStoryDb GetByUserId(string userId);
        SearchStoryDb GetByRequestId(string requestId);
        void Save(SearchStoryDb story);
        void Delete(string storyId);
    }
}
