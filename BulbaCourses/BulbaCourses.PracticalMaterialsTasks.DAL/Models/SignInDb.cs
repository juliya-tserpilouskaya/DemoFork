using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Models
{
    public class SignInDb
    {
        private string Password { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
    }
}