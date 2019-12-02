using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class UserStorage
    {
        private static List<RegisteredUser> _users = new List<RegisteredUser>() {
        new RegisteredUser()
        {
            Login= "Login",
            Password= "Password",
            Email= "MyEmail",
            Items = new List<Bookmark>()
                {
                    new Bookmark()
                    {
                        UserId = Guid.NewGuid().ToString(),
                        BookmarkDescription = "My new Bookmark 3"
                    },
                    new Bookmark()
                    {
                        UserId = Guid.NewGuid().ToString(),
                        BookmarkDescription = "My new Bookmark 4"
                    },
                },
        },
        new RegisteredUser()
        {
            Login= "Login2",
            Password= "Password2",
            Email= "MyEmail2",
            Items = new List<Bookmark>()
                {
                    new Bookmark()
                    {
                        UserId = Guid.NewGuid().ToString(),
                        BookmarkDescription = "My new Bookmark 5"
                    },
                    new Bookmark()
                    {
                        UserId = Guid.NewGuid().ToString(),
                        BookmarkDescription = "My new Bookmark 6"
                    },
                },
        }
        };

        /// <summary>
        /// Get all users from list (BD). Modification prohibited.
        /// </summary>
        /// <returns>Readonly list of users</returns>
        public static IEnumerable<RegisteredUser> GetAll()
        {
            return _users.AsReadOnly();
        }

        /// <summary>
        /// Get user from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid UserId number</param>
        /// <returns>ID user</returns>
        public static RegisteredUser GetById(string id)
        {
            return _users.SingleOrDefault(user => user.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add one new user into list with ID (Generated on server).
        /// </summary>
        /// <param name="registeredUser">Enter Registered User properties to add</param>
        /// <returns>Added RegisteredUser</returns>
        public static RegisteredUser Add(RegisteredUser registeredUser)
        {
            registeredUser.UserId = Guid.NewGuid().ToString();
            _users.Add(registeredUser);
            return registeredUser;
        }

        /// <summary>
        /// Remove one user from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid UserId number</param>
        public static void RemoveById(string id)
        {
            var user = _users.SingleOrDefault(u => u.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
            _users.Remove(user);
        }

        /// <summary>
        /// Remove all users from list.
        /// </summary>
        public static void RemoveAll()
        {
            _users.Clear();
        }
    }
}