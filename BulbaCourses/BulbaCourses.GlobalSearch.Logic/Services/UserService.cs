using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class UserService : IUserService
    {
        IUserDbService _userDb;
        IMapper _mapper;

        public UserService(IMapper mapper, IUserDbService userDb)
        {
            _userDb = userDb;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDB>, List<UserDTO>>(_userDb.GetAll());
        }

        /// <summary>
        /// Asynchronously returns all users
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var data = await _userDb.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDB>, List<UserDTO>>(data);
        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        public UserDTO GetById(string id)
        {
            return _mapper.Map<UserDB, UserDTO>(_userDb.GetById(id));
        }

        /// <summary>
        /// Asynchronously returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _userDb.GetByIdAsync(id);
            return _mapper.Map<UserDB, UserDTO>(user);
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        public UserDTO Add(UserDTO user)
        {
            UserDB userDb = new UserDB() { Id = user.Id, Authorization = user.Authorization };
            return _mapper.Map<UserDB, UserDTO>(_userDb.Add(userDb));
        }

        /// <summary>
        /// Returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        public IEnumerable<BookmarkDTO> GetBookmarksByUserId(string id)
        {
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(_userDb.GetBookmarksByUserId(id));
        }

        /// <summary>
        /// Asynchronously returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        public async Task<IEnumerable<BookmarkDTO>> GetBookmarksByUserIdAsync(string id)
        {
            var data = await _userDb.GetBookmarksByUserIdAsync(id);
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(data);
        }

        /// <summary>
        /// Returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        public IEnumerable<SearchQueryDTO> GetSearchQueriesByUserId(string id)
        {
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(_userDb.GetSearchQueriesByUserId(id));
        }

        /// <summary>
        /// Asynchronously returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        public async Task<IEnumerable<SearchQueryDTO>> GetSearchQueriesByUserIdAsync(string id)
        {
            var data = await _userDb.GetSearchQueriesByUserIdAsync(id);
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(data);
        }

        /// <summary>
        /// Removes user by id
        /// </summary>
        /// <param name="id">User id</param>
        public void RemoveById(string id)
        {
            _userDb.RemoveById(id);
        }

        /// <summary>
        /// Removes all users from database
        /// </summary>
        public void RemoveAll()
        {
            _userDb.RemoveAll();
        }
    }
}
