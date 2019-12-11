using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbaCourses.PracticalMaterialsTasks.Web.Models
{
    [Table("Profile")]
    public class Profile
    {
        [Key]
        [Required]
        public string ProfileId { get; set; } = Guid.NewGuid().ToString();

        public string Progress { get; set; }

        public string Rank { get; set; }

        public int Complited { get; set; }

        public int UserId { get; set; }

    }
}