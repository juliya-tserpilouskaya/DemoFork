using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
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
        private readonly IMapper mapper;
        private readonly IBookmarkServiceDb _bookmarkServiceDb;

        public CourseBookmarkServices(IMapper mapper, IBookmarkServiceDb bookmarkServiceDb)
        {
            this.mapper = mapper;
            _bookmarkServiceDb = bookmarkServiceDb;
        }
        public IEnumerable<CourseBookmark> GetAll()
        {
            var bookmarks = _bookmarkServiceDb.GetAll();
            var result = mapper.Map<IEnumerable<CourseBookmarkDb>, IEnumerable<CourseBookmark>>(bookmarks);
            return result;
        }

        public async Task<CourseBookmark> AddAsync(CourseBookmark courseBookmark)
        {
            courseBookmark.Id = Guid.NewGuid().ToString();
            var bookmarkDb = mapper.Map<CourseBookmark, CourseBookmarkDb>(courseBookmark);
            await _bookmarkServiceDb.AddAsync(bookmarkDb);
            return courseBookmark;
        }


        public void DeleteById(string id)
        {
            var bookmark = _bookmarkServiceDb.GetById(id);
            _bookmarkServiceDb.Delete(bookmark);
        }

    }
}
