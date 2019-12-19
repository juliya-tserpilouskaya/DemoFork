using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Save User
        /// </summary>
        /// <param name="user"></param>
        public UserDb Save(UserDb user)
        {
            return user != null ? _userRepository.Save(user) : user;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDb> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDb GetUserById(int? userId)
        {
            return _userRepository.GetById(userId);
        }

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUserById(int? userId)
        {
            if (userId != null)
                _userRepository.DeleteById(userId);
        }

        /// <summary>
        /// Check if User exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Exists(UserDb user)
        {
            return _userRepository.Exists(user);
        }
    }
}
