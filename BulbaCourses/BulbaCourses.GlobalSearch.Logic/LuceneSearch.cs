using BulbaCourses.GlobalSearch.Logic.DTO;
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

namespace BulbaCourses.GlobalSearch.Logic
{
    public static class LuceneSearch
    {

        private static string _luceneDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"/searchIndex";

        private static FSDirectory _directoryTemp;

        private static FSDirectory _directory
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
        /// Creates a single search index entry based on our data, and it will be reused by public methods which we'll add later
        /// </summary>
        /// <param name="courseData"></param>
        /// <param name="writer"></param>
        private static void _addToLuceneIndex(LearningCourseDTO courseData, IndexWriter writer)
        {
            // remove older index entry
            var searchQuery = new TermQuery(new Term("Id", courseData.Id.ToString()));
            writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();

            // add lucene fields mapped to db fields
            doc.Add(new Field("Id", courseData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Description", courseData.Description.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            //doc.Add(new Field("Content", courseData.Content, Field.Store.YES, Field.Index.ANALYZED));

            // add entry to index
            writer.AddDocument(doc);
        }

        /// <summary>
        /// Method that will use _addToLuceneIndex() in order to add a list of records to search index
        /// </summary>
        /// <param name="sampleDatas"></param>
        public static void AddUpdateLuceneIndex(IEnumerable<LearningCourseDTO> sampleDatas)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entry if any)
                foreach (var sampleData in sampleDatas)
                {
                    _addToLuceneIndex(sampleData, writer);
                };

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        /// <summary>
        /// method that will add a single record to search index
        /// </summary>
        /// <param name="sampleData"></param>
        public static void AddUpdateLuceneIndex(LearningCourseDTO sampleData)
        {
            AddUpdateLuceneIndex(new List<LearningCourseDTO> { sampleData });
        }

        /// <summary>
        /// Method to remove single record from Lucene 
        /// search index by record's Id field:
        /// </summary>
        /// <param name="record_id"></param>
        public static void ClearLuceneIndexRecord(int record_id)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // remove older index entry
                var searchQuery = new TermQuery(new Term("Id", record_id.ToString()));
                writer.DeleteDocuments(searchQuery);

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        /// <summary>
        /// Method to clear all index
        /// </summary>
        /// <returns></returns>
        public static bool ClearLuceneIndex()
        {
            try
            {
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                using (var writer = new IndexWriter(_directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    // remove older index entries
                    writer.DeleteAll();

                    // close handles
                    analyzer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lucene search index optimization
        /// </summary>
        public static void Optimize()
        {
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }

        /// <summary>
        /// a function that will map index to our class
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static LearningCourseDTO _mapLuceneDocumentToData(Document doc)
        {
            return new LearningCourseDTO
            {
                Id = doc.Get("Id"),
                Description = doc.Get("Description")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hits"></param>
        /// <returns></returns>
        private static IEnumerable<LearningCourseDTO> _mapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(_mapLuceneDocumentToData).ToList();
        }
        private static IEnumerable<LearningCourseDTO> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits,
            IndexSearcher searcher)
        {
            return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }

        /// <summary>
        /// Format search request for a particular search scenario
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        private static Query parseQuery(string searchQuery, QueryParser parser)
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
        private static IEnumerable<LearningCourseDTO> _search(string searchQuery, string searchField = "")
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
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
                // search by multiple fields (ordered by RELEVANCE)

                else
                {
                    var parser = new MultiFieldQueryParser
                        (Lucene.Net.Util.Version.LUCENE_30, new[] { "Id", "Description" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search
                    (query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
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
        public static IEnumerable<LearningCourseDTO> Search(string input, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input)) return new List<LearningCourseDTO>();

            var terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);

            return _search(input, fieldName);
        }

        /// <summary>
        ///  for trying out native Lucene search querries we can add default search 
        ///  method SearchDefault(), which doesn't format your query in any manner:
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static IEnumerable<LearningCourseDTO> SearchDefault(string input, string fieldName = "")
        {
            return string.IsNullOrEmpty(input) ? new List<LearningCourseDTO>() : _search(input, fieldName);
        }

        /// <summary>
        /// method to return the whole Lucene search index
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<LearningCourseDTO> GetAllIndexRecords()
        {
            // validate search index
            if (!System.IO.Directory.EnumerateFiles(_luceneDir).Any()) return new List<LearningCourseDTO>();

            // set up lucene searcher
            var searcher = new IndexSearcher(_directory, false);
            var reader = IndexReader.Open(_directory, false);
            var docs = new List<Document>();
            var term = reader.TermDocs();
            while (term.Next()) docs.Add(searcher.Doc(term.Doc));
            reader.Dispose();
            searcher.Dispose();
            return _mapLuceneToDataList(docs);
        }
    }
}
