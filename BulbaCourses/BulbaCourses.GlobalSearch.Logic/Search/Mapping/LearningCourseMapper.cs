using BulbaCourses.GlobalSearch.Logic.DTO;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Search.Mapping
{
    public class LearningCourseMapper
    {
        /// <summary>
        /// a function that will map index to our class
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public LearningCourseDTO MapLuceneDocumentToData(Document doc)
        {
            return new LearningCourseDTO
            {
                Id = doc.Get("Id"),
                Description = doc.Get("Description"),
                Name = doc.Get("Name"),
                Category = Convert.ToInt32(doc.Get("Category")),
                Cost = Convert.ToDouble(doc.Get("Cost")),
                Complexity = doc.Get("Complexity"),
                Language = doc.Get("Language"),
                AuthorId = Convert.ToInt32(doc.Get("AuthorId")),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hits"></param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> MapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(MapLuceneDocumentToData).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hits"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        public IEnumerable<LearningCourseDTO> MapLuceneToDataList(IEnumerable<ScoreDoc> hits,
            IndexSearcher searcher)
        {
            return hits.Select(hit => MapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }
    }
}
