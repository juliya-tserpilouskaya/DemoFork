using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbaCourses.PracticalMaterialsTasks.Web.Models
{
    [Table("Settings")]
    public class Settings
    {
  
       public string SettingsId { get; set; } = Guid.NewGuid().ToString();

       public int UserLvlChange { get; set; }

       public int UserId { get; set; } 




    }
}