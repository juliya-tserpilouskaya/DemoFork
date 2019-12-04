using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class Course //получаем из другого домена, нужна ли эта сущность??
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}