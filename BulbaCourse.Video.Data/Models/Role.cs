using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class Role
    {
        public string RoleId { get; set; } = Guid.NewGuid().ToString();
        public string RoleName { get; set; }
    }
}
