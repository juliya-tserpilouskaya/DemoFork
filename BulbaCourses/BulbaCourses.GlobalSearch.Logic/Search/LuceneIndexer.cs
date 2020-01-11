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
    public class LuceneIndexer
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
        /// Creates a single search index entry based on our data, and it will be reused by public methods which we'll add later
        /// </summary>
        /// <param name="courseData"></param>
        /// <param name="writer"></param>
        private void _addToLuceneIndex(LearningCourseDTO courseData, IndexWriter writer)
        {
            // remove older index entry
            var searchQuery = new TermQuery(new Term("Id", courseData.Id.ToString()));
            writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();

            // add lucene fields mapped to db fields
            doc.Add(new Field("Id", courseData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Description", courseData.Description.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Name", courseData.Name.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Category", courseData.Category.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Cost", courseData.Cost.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Complexity", courseData.Complexity.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Language", courseData.Language.ToString(), Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("AuthorId", courseData.AuthorId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

            // add entry to index
            writer.AddDocument(doc);
        }

        /// <summary>
        /// Method that will use _addToLuceneIndex() in order to add a list of records to search index
        /// </summary>
        /// <param name="sampleDatas"></param>
        public void AddUpdateLuceneIndex(IEnumerable<LearningCourseDTO> sampleDatas)
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
        public void AddUpdateLuceneIndex(LearningCourseDTO sampleData)
        {
            AddUpdateLuceneIndex(new List<LearningCourseDTO> { sampleData });
        }

        /// <summary>
        /// Method to remove single record from Lucene 
        /// search index by record's Id field:
        /// </summary>
        /// <param name="record_id"></param>
        public void ClearLuceneIndexRecord(int record_id)
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
        /// method to return the whole Lucene search index
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> GetAllIndexRecords()
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

            var mapper = new LearningCourseMapper();

            return mapper.MapLuceneToDataList(docs);
        }

        /// <summary>
        /// Method to clear all index
        /// </summary>
        /// <returns></returns>
        public bool ClearLuceneIndex()
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
        public void Optimize()
        {
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }
    }
}
