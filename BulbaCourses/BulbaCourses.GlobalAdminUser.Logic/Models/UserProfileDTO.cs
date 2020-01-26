using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Models
{
    public class UserProfileDTO
    {
        public string Id { get; set; }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }

        public IEnumerable<ProfileParamsDTO> ProfileParams { get; set; }
    }
}
