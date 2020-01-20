using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Search;
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
            var searcher = new LuceneSearcher();
            return searcher.Search(query);
        }

        public IEnumerable<LearningCourseDTO> GetIndexedCourses()
        {

            var indexer = new LuceneIndexer();

            return indexer.GetAllIndexRecords();

        }

        public IEnumerable<LearningCourseDTO> IndexCourse(LearningCourseDTO course)
        {

            var indexer = new LuceneIndexer();
            indexer.AddUpdateLuceneIndex(course);
            return indexer.GetAllIndexRecords();
        }

        public Task<IEnumerable<LearningCourseDTO>> SearchAsync()
        {
            throw new NotImplementedException();
        }

    }
}
