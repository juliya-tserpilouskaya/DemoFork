using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbaCourses.PracticalMaterialsTasks.Web.Models
{
    [Table("User")]
    public class User
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        [StringLength(20)]
        [Required]
        public string Login { get; set; }

        [StringLength(20)]
        [Required]
        public string Password { get; set; }

        [StringLength(20)]
        public string NewPassword { get; set; }

        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [StringLength(30)]
        public string Email { get; set; } 

        public bool LoginIN { get; set; }

    }
}