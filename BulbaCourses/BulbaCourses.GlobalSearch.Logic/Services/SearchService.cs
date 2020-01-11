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
    class SearchService : ISearchService
    {
        ICourseDbService _learningCourseDb;

        public SearchService(ICourseDbService learningCourseDb)
        {
            _learningCourseDb = learningCourseDb;
        }

        public IEnumerable<LearningCourseDTO> Search(string query)
        {
            return LuceneSearch.Search(query);
        }

        public IEnumerable<LearningCourseDTO> GetIndexedCourses()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDB, LearningCourseDTO>();
            }).CreateMapper();

            var data = _learningCourseDb.GetAllCourses();

            var repoItems = mapper.Map<IEnumerable<CourseDB>, List<LearningCourseDTO>>(data);

            LuceneSearch.AddUpdateLuceneIndex(repoItems);

            return LuceneSearch.GetAllIndexRecords();
        }

        public Task<IEnumerable<LearningCourseDTO>> SearchAsync()
        {
            throw new NotImplementedException();
        }

    }
}
