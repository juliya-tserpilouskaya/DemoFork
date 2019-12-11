using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbaCourses.PracticalMaterialsTasks.Web.Models
{
    public class Task
    {
        public string TaskId { get; set; } = Guid.NewGuid().ToString();

        public string TaskInformation { get; set; }

        public string CategoryTask { get; set; }

    }
}