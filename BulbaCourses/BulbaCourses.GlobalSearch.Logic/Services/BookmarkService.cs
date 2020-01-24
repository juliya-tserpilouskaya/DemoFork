using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    public class BookmarkService : IBookmarkService
    {
        IBookmarkDbService _bookmarkDb;
        IMapper _mapper;

        public BookmarkService(IMapper mapper, IBookmarkDbService bookmarkDb)
        {
            _bookmarkDb = bookmarkDb;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookmarkDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(_bookmarkDb.GetAll());
        }

        /// <summary>
        /// Asynchronously returns all bookmarks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookmarkDTO>> GetAllAsync()
        {
            var data = await _bookmarkDb.GetAllAsync();
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(data);
        }

        /// <summary>
        /// Returns bookmark by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public BookmarkDTO GetById(string id)
        {
            var bookmark = _bookmarkDb.GetById(id);
            return new BookmarkDTO { Id = bookmark.Id, UserId = bookmark.UserId, Title = bookmark.Title, URL = bookmark.URL };
        }

        /// <summary>
        /// Asynchronously returns bookmark by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public async Task<BookmarkDTO> GetByIdAsync(string id)
        {
            var bookmark = await _bookmarkDb.GetByIdAsync(id);
            return new BookmarkDTO { Id = bookmark.Id, UserId = bookmark.UserId, Title = bookmark.Title, URL = bookmark.URL };
        }

        /// <summary>
        /// Returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        public IEnumerable<BookmarkDTO> GetByUserId(string userID)
        {
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(_bookmarkDb.GetByUserId(userID));
        }

        /// <summary>
        /// Asynchronously returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookmarkDTO>> GetByUserIdAsync(string userID)
        {
            var data = await _bookmarkDb.GetByUserIdAsync(userID);
            return _mapper.Map<IEnumerable<BookmarkDB>, List<BookmarkDTO>>(data);
        }

        /// <summary>
        /// Creates bookmark
        /// </summary>
        /// <param name="bookmark">search query</param>
        /// <returns></returns>
        public BookmarkDTO Add(BookmarkDTO bookmark)
        {
            BookmarkDB bookmarkDb = new BookmarkDB() { Id = bookmark.Id, UserId = bookmark.UserId, Title = bookmark.Title, URL = bookmark.URL };
            return _mapper.Map<BookmarkDB, BookmarkDTO>(_bookmarkDb.Add(bookmarkDb));
        }

        /// <summary>
        /// Creates bookmark async
        /// </summary>
        /// <param name="bookmark">search query</param>
        /// <returns></returns>
        public async Task<Result<BookmarkDTO>> AddAsync(BookmarkDTO bookmark)
        {
            BookmarkDB bookmarkDb = new BookmarkDB() { Id = bookmark.Id, UserId = bookmark.UserId, Title = bookmark.Title, URL = bookmark.URL };
            var result = await _bookmarkDb.AddAsync(bookmarkDb);
            return result.IsSuccess ? Result<BookmarkDTO>.Ok(_mapper.Map<BookmarkDTO>(result.Data))
                : Result<BookmarkDTO>.Fail<BookmarkDTO>(result.Message);
        }

        /// <summary>
        /// Removes bookmarks by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public void RemoveById(string id)
        {
            _bookmarkDb.RemoveById(id);
        }

        /// <summary>
        /// Removes bookmarks by id async
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public Task<Result> RemoveByIdAsync(string id)
        {
            _bookmarkDb.RemoveByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }

        /// <summary>
        /// Removes all bookmarks from database
        /// </summary>
        public void RemoveAll()
        {
            _bookmarkDb.RemoveAll();
        }
    }
}
