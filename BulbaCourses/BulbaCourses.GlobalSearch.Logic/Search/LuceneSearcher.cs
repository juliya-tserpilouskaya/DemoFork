using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.Search.Mapping;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BulbaCourses.GlobalSearch.Logic.Search
{
    public class LuceneSearcher
    {

        private string _luceneDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"/searchIndex";

        private FSDirectory _directoryTemp;

        private FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_luceneDir, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }

        /// <summary>
        /// Format search request for a particular search scenario
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        private Query parseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="searchField"></param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetSearchResults(string searchQuery, string searchField = "")
        {
            // validation
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<LearningCourseDTO>();

            // set up lucene searcher
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hits_limit = 1000;
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

                //if one need to add new field to search:
                //var parser = new MultiFieldQueryParser
                //(Version.LUCENE_30, new[] { "Id", "Name", "Description", "NEW_FIELD" }, analyzer);

                // search by single field
                if (!string.IsNullOrEmpty(searchField))
                {
                    var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, searchField, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, hits_limit).ScoreDocs;

                    var mapper = new LearningCourseMapper();

                    var results = mapper.MapLuceneToDataList(hits, searcher);

                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
                // search by multiple fields (ordered by RELEVANCE)

                else
                {
                    var parser = new MultiFieldQueryParser
                        (Lucene.Net.Util.Version.LUCENE_30, new[] { "Name", "Description" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search
                    (query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;

                    var mapper = new LearningCourseMapper();

                    var results = mapper.MapLuceneToDataList(hits, searcher);

                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
        }

        /// <summary>
        /// formats Lucene search query and calls private _search method
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> Search(string input, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input)) return new List<LearningCourseDTO>();

            var terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);

            return GetSearchResults(input, fieldName);
        }

        /// <summary>
        ///  for trying out native Lucene search querries we can add default search 
        ///  method SearchDefault(), which doesn't format your query in any manner:
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> SearchDefault(string input, string fieldName = "")
        {
            return string.IsNullOrEmpty(input) ? new List<LearningCourseDTO>() : GetSearchResults(input, fieldName);
        }
    }
}
