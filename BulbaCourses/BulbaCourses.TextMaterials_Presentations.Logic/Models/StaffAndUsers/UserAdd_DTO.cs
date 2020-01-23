using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Logic
{
    public class UserAdd_DTO
    {
        public DateTime? Created { get; set; } = DateTime.Now;

        public string PhoneNumber { get; set; }
    }
}
