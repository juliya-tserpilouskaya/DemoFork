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

        public SearchService(IMapper mapper, ICourseRepository courseRepository, ITegRepository tegRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _tegRepository = tegRepository;
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
                    var courses = await _courseRepository.GetAllAsync();
                    courses = courses.Where(c => c.Tags.Contains(tag));
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
                    var allCourses = await _courseRepository.GetAllAsync();
                    var courses = allCourses.Where(c => c.Author.Name.Contains(searchRequest));
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
