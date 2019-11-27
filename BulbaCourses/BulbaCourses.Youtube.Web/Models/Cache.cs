using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Cache // с этого места начинается путаница и сомнения... что такое кеш для наших моделей? связь запрос-ответ для конкретного пользователя?
    {
        public int Id { get; set; }
        public int SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public DateTime SearchDate { get; set; }//нужна дата?
    }
}