using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// The list of Users, static, CRUD operations
/// </summary>
    public static class UserBase
    {
        private static List<User> _users = new List<User>();

        /// <summary>
        /// Get all Users from the list of Users, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<User> GetAll()
        {
            return _users.AsReadOnly();
        }

        /// <summary>
        /// Get User from the list of Users by Id, returns User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetById(string id)
        {
            return _users.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add User to the list of Users, returns added User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return user;
        }

        /// <summary>
        /// Find the User whis the same Id from the list of Users delete it and add new, returns added User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete by Id User from the list of Users, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(string id)
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