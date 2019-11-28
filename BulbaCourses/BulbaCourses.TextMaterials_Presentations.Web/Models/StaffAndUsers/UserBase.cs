using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{
    public static class UserBase
    {
        private static List<User> _users = new List<User>();

        public static IEnumerable<User> GetAll()
        {
            return _users.AsReadOnly();
        }

        public static User GetById(string id)
        {
            return _users.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static User Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return user;
        }

        public static User Update(User user)
        {
            User deletedUser = _users.SingleOrDefault(p => p.Id.Equals(user.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedUser != null)
            {
                _users.Remove(deletedUser);
                user.Id = Guid.NewGuid().ToString();
                _users.Add(user);
            }
            else
            {
                return deletedUser;
            }

            return user;
        }

        public static bool DeletById(string id)
        {
            User deletedPresentation = _users.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                _users.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}