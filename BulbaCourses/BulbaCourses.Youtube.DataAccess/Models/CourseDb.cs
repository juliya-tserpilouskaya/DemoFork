using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class CourseDb //получаем из другого домена, нужна ли эта сущность??
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}