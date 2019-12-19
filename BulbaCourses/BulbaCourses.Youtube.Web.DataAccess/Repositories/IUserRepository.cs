using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Save User 
        /// </summary>
        /// <param name="user"></param>
        UserDb Save(UserDb user);

        /// <summary>
        /// Get all Users 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        IEnumerable<UserDb> GetAll();

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDb GetById(int? userId);

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteById(int? userId);

        /// <summary>
        /// Check if User exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Exists(UserDb user);
    }
}
