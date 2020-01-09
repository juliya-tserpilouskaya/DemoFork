using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Models
{
    public class TaskDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Text { get; set; }
        public string TaskLevel { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}