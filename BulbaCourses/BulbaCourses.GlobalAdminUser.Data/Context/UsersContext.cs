using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    public class UsersContext : IUsersContext
    {
        private HttpClient _client = new HttpClient();
        public UsersContext()
        {
            _client.BaseAddress = new Uri("http://localhost:44382/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<UserDb>> GetAll()
        {
            IEnumerable<UserDb> users = null;
            HttpResponseMessage response = await _client.GetAsync("api/admin");
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<IEnumerable<UserDb>>();
            }
            return users;
        }
    }
}
