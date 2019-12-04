using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Entities.Actors
{
    public abstract class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}