using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Cache // что такое кеш для наших моделей? 
    {
        public SearchRequest SearchRequest { get; set; }
        public Result Result { get; set; }
    }

    public class Cache1 //
    {
        public int Id { get; set; }
        public int SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
    }
}