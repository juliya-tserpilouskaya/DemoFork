using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class AnonymousUserService : IAnonymousUserService
    {
        public AnonymousUser Add(AnonymousUser anonymousUser)
        {
            return AnonymousUserStorage.Add(anonymousUser);
        }

        public IEnumerable<AnonymousUser> GetAll()
        {
            return AnonymousUserStorage.GetAll();
        }

        public AnonymousUser GetById(string id)
        {
            return AnonymousUserStorage.GetById(id);
        }

        public void RemoveAll()
        {
            AnonymousUserStorage.RemoveAll();
        }

        public void RemoveById(string id)
        {
            AnonymousUserStorage.RemoveById(id);
        }
    }
}
