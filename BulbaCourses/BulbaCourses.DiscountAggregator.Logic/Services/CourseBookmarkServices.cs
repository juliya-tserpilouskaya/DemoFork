using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseBookmarkServices : ICourseBookmarkServices
    {
        private readonly IMapper _mapper;
        private readonly IBookmarkServiceDb _bookmarkServiceDb;

        public CourseBookmarkServices(IMapper mapper, IBookmarkServiceDb bookmarkServiceDb)
        {
            this._mapper = mapper;
            _bookmarkServiceDb = bookmarkServiceDb;
        }

        public async Task<IEnumerable<CourseBookmark>> GetByUserIdAsync(string userId)
        {
            var bookmarks = await _bookmarkServiceDb.GetByUserIdAsync(userId);
            var result = _mapper.Map<IEnumerable<CourseBookmarkDb>, IEnumerable<CourseBookmark>>(bookmarks);
            return result;
        }

        public async Task<Result<CourseBookmark>> AddAsync(CourseBookmark bookmark)
        {
            bookmark.Id = Guid.NewGuid().ToString();
            var bookmarkDb = _mapper.Map<CourseBookmark, CourseBookmarkDb>(bookmark);
            var result = await _bookmarkServiceDb.AddAsync(bookmarkDb);
            return result.IsSuccess ? Result<CourseBookmark>.Ok(_mapper.Map<CourseBookmark>(result.Data))
                : (Result<CourseBookmark>)Result.Fail(result.Message);
        }

        public async Task<Result<CourseBookmark>> DeleteAsync(CourseBookmark bookmark)
        {
            var bookmarkDb = _mapper.Map<CourseBookmark, CourseBookmarkDb>(bookmark);
            var result = await _bookmarkServiceDb.DeleteAsync(bookmarkDb);
            
            return result.IsSuccess ? Result<CourseBookmark>.Ok(_mapper.Map<CourseBookmark>(result.Data))
                : (Result<CourseBookmark>)Result.Fail(result.Message);
        }
    }
}
