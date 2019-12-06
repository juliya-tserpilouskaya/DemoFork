using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Logic.Models
{
    public class AnonymousUserStorage
    {
        private static List<AnonymousUser> _users = new List<AnonymousUser>() {
        new AnonymousUser()
        {
            Items = new List<SearchQuery>()
                {
                    new SearchQuery()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Query = "Basics c#",
                        Date = DateTime.Now,
                    },
                    new SearchQuery()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Query = "Basics c++",
                        Date = DateTime.Now,
                    },
                },
        },
        new AnonymousUser()
        {
            Items = new List<SearchQuery>()
                {
                    new SearchQuery()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Query = "Advanced c#",
                        Date = DateTime.Now,
                    },
                    new SearchQuery()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Query = "Advanced c#",
                        Date = DateTime.Now,
                    },
                },
        }
        };

        /// <summary>
        /// Get all users from list (BD). Modification prohibited.
        /// </summary>
        /// <returns>Readonly list of users</returns>
        public static IEnumerable<AnonymousUser> GetAll()
        {
            return _users.AsReadOnly();
        }

        /// <summary>
        /// Get user from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid AnonymousUser number</param>
        /// <returns>ID user</returns>
        public static AnonymousUser GetById(string id)
        {
            return _users.SingleOrDefault(user => user.AnonymousUserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add one new user into list with ID (Generated on server).
        /// </summary>
        /// <param name="anonymousUser">Enter Anonymous User properties to add</param>
        /// <returns>Added AnonymousUser</returns>
        public static AnonymousUser Add(AnonymousUser anonymousUser)
        {
            anonymousUser.AnonymousUserId = Guid.NewGuid().ToString();
            _users.Add(anonymousUser);
            return anonymousUser;
        }

        /// <summary>
        /// Remove one user from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid AnonymousUser number</param>
        public static void RemoveById(string id)
        {
            var user = _users.SingleOrDefault(u => u.AnonymousUserId.Equals(id, StringComparison.OrdinalIgnoreCase));
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