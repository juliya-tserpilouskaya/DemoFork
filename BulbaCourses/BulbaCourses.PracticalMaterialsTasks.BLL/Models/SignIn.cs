using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Models
{
    public class SignIn
    {
        private string Password { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
    }
}