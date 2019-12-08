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
        /// <summary>
        /// Save story for User
        /// </summary>
        /// <param name="story"></param>
        SearchStoryDb Save(SearchStoryDb story);

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteByUserId(int? userId);

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        void DeleteByStoryId(int? storyId);

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        /// <summary>
        IEnumerable<SearchStoryDb> GetAll();

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetByUserId(int? userId);

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        IEnumerable<SearchStoryDb> GetByRequestId(int? requestId);

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        SearchStoryDb GetByStoryId(int? storyId);
    }
}
