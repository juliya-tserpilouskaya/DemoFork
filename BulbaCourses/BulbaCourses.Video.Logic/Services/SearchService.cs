using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    public class SearchService : ISearchService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ITegRepository _tegRepository;
        private readonly IAuthorRepository _authorRepository;

        public SearchService(IMapper mapper, ICourseRepository courseRepository, ITegRepository tegRepository, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _tegRepository = tegRepository;
            _authorRepository = authorRepository;
        }
        public async Task<IEnumerable<CourseInfo>> GetSearchCourses(string searchRequest, SearchVariant variant)
        {
            IEnumerable<CourseInfo> coursesInfo = null;
            if (variant == SearchVariant.ByName)
            {
                try
                {
                    var allCourses = await _courseRepository.GetAllAsync();
                    var courses = allCourses.Where(c => c.Name.Contains(searchRequest));
                    coursesInfo = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
                }
                catch (KeyNotFoundException)
                {
                    coursesInfo = null;
                }
            }
            else if (variant == SearchVariant.ByTag)
            {
                try
                {
                    var tag = _tegRepository.GetAll().FirstOrDefault(c => c.Content.Equals(searchRequest));
                    if (tag == null)
                    {
                        tag.TagId = Guid.NewGuid().ToString();
                        tag.Content = searchRequest;
                    }

                    var courses = await _tegRepository.GetCoursesAsync(tag);
                    coursesInfo = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
                }
                catch (KeyNotFoundException)
                {
                    coursesInfo = null;
                }
            }
            else if (variant == SearchVariant.ByAuthor)
            {
                try
                {
                    var author = _authorRepository.GetAllAsync().GetAwaiter().GetResult().FirstOrDefault(c => c.Lastname.Equals(searchRequest));

                    var courses = await _courseRepository.GetByAuthorAsync(author);
                    coursesInfo = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
                }
                catch (KeyNotFoundException)
                {
                    coursesInfo = null;
                }
            }

            return coursesInfo;
        }
    }
}
