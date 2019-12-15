using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IUserService
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
        IEnumerable<UserDb> GetAllUsers();

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDb GetUserById(int? userId);

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUserById(int? userId);

        /// <summary>
        /// Check if User exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Exists(UserDb user);
    }
}
