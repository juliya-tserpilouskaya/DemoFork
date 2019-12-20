using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.Web.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        User[] users = new User[]
        {
            new User { Id = "1", FirstName="Alex", LastName="Russo",NickName="AlexRusso"},
            new User { Id = "2", FirstName="Jane", LastName="Ostin",NickName="JaneOstin"},
            new User { Id = "3", FirstName="Pall", LastName="Brown",NickName="PallBrown"}
        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }
        public IHttpActionResult GetUser(string id)
        {
            var user = users.FirstOrDefault((u) => u.Id == id);
            return Ok(user);
        }
    }
}
