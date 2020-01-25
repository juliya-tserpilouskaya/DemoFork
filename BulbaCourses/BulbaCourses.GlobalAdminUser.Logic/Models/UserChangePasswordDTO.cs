using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Models
{
    public class UserChangePasswordDTO
    {
        public string Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordConfirm { get; set; }
    }
}
