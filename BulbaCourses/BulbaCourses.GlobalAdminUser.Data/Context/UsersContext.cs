using BulbaCourses.GlobalAdminUser.Data.Models;
using Newtonsoft.Json;
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

        public async Task<UserDb> GetById(string id)
        {
            UserDb user = null;
            HttpResponseMessage response = await _client.GetAsync($"api/admin/id?id={id}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserDb>();
            }
            return user;
        }

        public async Task ChangePassword(UserChangePassword user)
        {
            string json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync("api/admin", httpContent);
        }



        #region roles
        public async Task<IEnumerable<RoleDb>> GetRolesAsync()
        {
            IEnumerable<RoleDb> roles = null;
            HttpResponseMessage response = await _client.GetAsync("api/admin/roles");
            if (response.IsSuccessStatusCode)
            {
                roles = await response.Content.ReadAsAsync<IEnumerable<RoleDb>>();
            }
            return roles;
        }
        #endregion
    }
}
