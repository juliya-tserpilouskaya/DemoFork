using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Models
{
    public class TaskDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string TaskLevel { get; set; }
    }
}