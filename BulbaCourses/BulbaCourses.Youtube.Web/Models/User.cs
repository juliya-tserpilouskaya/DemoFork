using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }  //скрыть надо бы..
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; } //возможно надо для авторизации, или восстановления пароля
        public IEnumerable<string> Email { get; set; } //для дополнительных(резервных) адресов
        public IEnumerable<Cache> Cache { get; set; }
        public IEnumerable<SearchStory> SearchStory { get; set; }
        public IEnumerable<FavoritesVideos> FavoritesVideos { get; set; }
        public IEnumerable<RecentVideos> RecentVideos { get; set; }
    } 
}